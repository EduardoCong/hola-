using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TostiElotes.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdenController : ControllerBase
    {
        private readonly OrdenServices _orderServices;
        private readonly DetalleOrdenServices _detallesOrdenServices;
        private readonly IMapper _mapper;
        private readonly ProductoServices _productoServices;
        private readonly ClienteServices _clienteServices;
        private readonly EstadoEntregaServices _estadoEntrega;

        public OrdenController(OrdenServices orderServices, DetalleOrdenServices detallesOrdenServices, IMapper mapper, ProductoServices productoServices, ClienteServices clienteServices, EstadoEntregaServices estadoEntrega)
        {
            _orderServices = orderServices ?? throw new ArgumentNullException(nameof(orderServices));
            _detallesOrdenServices = detallesOrdenServices ?? throw new ArgumentNullException(nameof(detallesOrdenServices));
            _productoServices = productoServices ?? throw new ArgumentNullException(nameof(productoServices));
            _clienteServices = clienteServices ?? throw new ArgumentNullException(nameof(clienteServices));
            _estadoEntrega = estadoEntrega ?? throw new ArgumentNullException(nameof(estadoEntrega));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Métodos para manejar órdenes
        [HttpPost("CreateNewOrden")]
        public async Task<IActionResult> CreateOrderAndDetails(OrderWithDetailsDTO orderWithDetails)
        {
            // Accede a los datos de la orden principal y el detalle de la orden
            var order = orderWithDetails.Order;
            var detalleOrdenCreate = orderWithDetails.DetalleOrden;

            // Resto del código para crear la orden y el detalle de la orden
            var orderEntity = _mapper.Map<Orden>(order);
            await _orderServices.Add(orderEntity);
            var orderDto = _mapper.Map<OrderDTO>(orderEntity);

            DetalleOrdenDTO? detalleOrdenDto = null;

            if (detalleOrdenCreate != null)
            {
                // Obtener el producto
                var producto = await _productoServices.GetById(detalleOrdenCreate.ID_Producto);

                // Verificar si el producto existe
                if (producto.IdProducto == 0)
                {
                    return BadRequest("El Producto no existe.");
                }

                var detalleOrdenEntity = _mapper.Map<DetalleOrden>(detalleOrdenCreate);
                detalleOrdenEntity.IdOrden = orderEntity.IdOrden;
                detalleOrdenEntity.IdProducto = detalleOrdenCreate.ID_Producto;
                await _detallesOrdenServices.Add(detalleOrdenEntity);
                detalleOrdenDto = _mapper.Map<DetalleOrdenDTO>(detalleOrdenEntity);

                // Calcula el precio total del detalle de la orden
                detalleOrdenDto.PrecioTotal = detalleOrdenCreate.Cantidad * producto.Precio;

                // Resta la cantidad de productos del stock correspondiente
                if (producto.Stock >= detalleOrdenCreate.Cantidad)
                {
                    producto.Stock -= detalleOrdenCreate.Cantidad;
                    await _productoServices.Update(producto); // Actualiza el stock
                }
                else
                {
                    // Maneja el caso en el que no hay suficiente stock
                    return BadRequest("Stock insuficiente para este producto.");
                }
            }

            // Crear un nuevo estado de entrega y asociarlo a la orden
            var estadoEntrega = new EstadoEntrega
            {
                IdOrden = orderEntity.IdOrden,
                Estado = "En proceso", // Puedes establecer el estado inicial que desees
                Comentarios = "Espero que le guste 😊"
            };

            await _estadoEntrega.Add(estadoEntrega); // Reemplaza ".Estado" con el método apropiado

            var response = new
            {
                Order = new
                {
                    orderDto.ID_Orden,
                    orderDto.Fecha,
                    orderDto.IdCliente,
                    orderDto.IdVendedor,
                    orderDto.DireccionEnvio,
                    orderDto.DetallesPago,
                    DetalleOrden = detalleOrdenDto // Agrega el detalleOrdenDto
                }
            };
            return Ok(response);
        }


        [HttpGet("Order")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderServices.GetAllIncludingDetails(); // Método personalizado para cargar detalles de la orden
            var orderDtos = orders.Select(order =>
            {
                var orderDto = _mapper.Map<OrderDTO>(order);
                orderDto.DetalleOrden = order.DetallesOrden.Select(detalle => _mapper.Map<DetalleOrdenDTO>(detalle)).ToList();
                return orderDto;
            }).ToList();

            return Ok(orderDtos);
        }



        [HttpGet("Order/{id:int}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderServices.GetById(id);
            if (order.IdOrden == 0)
                return BadRequest("La orden no existe.");

            // Obtiene los detalles de la orden correspondientes a la orden principal
            var detallesOrden = await _detallesOrdenServices.GetByOrderId(id);
            var orderDto = _mapper.Map<OrderDTO>(order);

            if (detallesOrden != null && detallesOrden.Any())
            {
                // Obtén la lista de ID_Producto de los detalles de la orden
                var idProductos = detallesOrden.Select(detalle => detalle.IdProducto).ToList();

                // Supongamos que tienes una función para cargar los productos por lista de ID_Producto
                var productos = await _productoServices.GetProductosById(idProductos);

                // Mapea los detalles de la orden a sus respectivos DTO
                var detallesOrdenDto = new List<DetalleOrdenDTO>();

                // Calcula el precio total de los detalles de la orden y agrega los detalles a detallesOrdenDto
                decimal totalPrice = 0;

                foreach (var detalle in detallesOrden)
                {
                    var producto = productos.FirstOrDefault(p => p.IdProducto == detalle.IdProducto);
                    if (producto != null)
                    {
                        var detalleDto = _mapper.Map<DetalleOrdenDTO>(detalle);
                        detalleDto.PrecioTotal = detalle.Cantidad * producto.Precio;
                        detallesOrdenDto.Add(detalleDto);
                        totalPrice += detalleDto.PrecioTotal;
                    }
                }

                // Asigna la lista de detalles ordenada al DTO de la orden

                // Actualiza el precio total en el primer elemento de detallesOrdenDto
                if (detallesOrdenDto.Any())
                {
                    detallesOrdenDto.First().PrecioTotal = totalPrice;
                }
            }

            return Ok(orderDto);
        }



        [HttpDelete("Order/{id:int}")]
        public async Task<IActionResult> DeleteOrder(int idOrden)
        {
            var existingOrder = await _orderServices.GetById(idOrden);

            if (existingOrder.IdOrden == 0)
            {
                return BadRequest("La orden no existe.");
            }
            else
            {
                // Elimina los detalles de orden correspondientes a la orden principal
                await _detallesOrdenServices.DeleteByOrderId(existingOrder.IdOrden);

                // Elimina la orden principal
                await _orderServices.Delete(idOrden);

                return Ok("La orden se ha eliminado correctamente");
            }
        }



        [HttpGet("OrdenesPorCliente")]
        public async Task<IActionResult> GetOrdersByClienteId(int IdCliente)
        {
            // Primero, verifica si el cliente existe
            var cliente = await _clienteServices.GetById(IdCliente);
            if (cliente.IdCliente == 0)
            {
                return NotFound("Cliente no encontrado");
            }

            // Crea un objeto anónimo que sigue el formato deseado
            var result = new
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Contraseña = cliente.Contraseña,
                Orden = new List<object>() // Puedes ajustar el tipo de datos aquí
            };

            // Obtiene las órdenes del cliente por su ID
            var ordenes = await _orderServices.GetOrdersByClienteId(IdCliente);

            // Proyecta cada orden en el nuevo formato
            foreach (var orden in ordenes)
            {
                var ordenInfo = new
                {
                    IdOrden = orden.IdOrden,
                    Fecha = orden.Fecha,
                    IdCliente = orden.IdCliente,
                    IdVendedor = orden.IdVendedor,
                    DireccionEnvio = orden.DireccionEnvio,
                    DetallesPago = orden.DetallesPago,
                    DetallesOrden = new List<object>() // Puedes ajustar el tipo de datos aquí
                };

                result.Orden.Add(ordenInfo);
            }

            return Ok(result);
        }
        
        // Métodos para manejar detalles de órdenes
        [HttpGet("DetallesOrden")]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            var detallesOrden = await _detallesOrdenServices.GetAll();
            var detallesOrdenDto = detallesOrden.Select(detalle => _mapper.Map<DetalleOrdenDTO>(detalle)).ToList();
            return Ok(detallesOrdenDto);
        }

    }


}
