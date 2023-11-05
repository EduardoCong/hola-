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

        public OrdenController(OrdenServices orderServices, DetalleOrdenServices detallesOrdenServices, IMapper mapper, ProductoServices productoServices, ClienteServices clienteServices)
        {
            _orderServices = orderServices ?? throw new ArgumentNullException(nameof(orderServices));
            _detallesOrdenServices = detallesOrdenServices ?? throw new ArgumentNullException(nameof(detallesOrdenServices));
            _productoServices = productoServices ?? throw new ArgumentNullException(nameof(productoServices));
            _clienteServices = clienteServices ?? throw new ArgumentNullException(nameof(clienteServices));
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
                var detalleOrdenEntity = _mapper.Map<DetalleOrden>(detalleOrdenCreate);
                detalleOrdenEntity.IdOrden = orderEntity.IdOrden;
                detalleOrdenEntity.IdProducto = detalleOrdenCreate.ID_Producto;
                await _detallesOrdenServices.Add(detalleOrdenEntity);
                detalleOrdenDto = _mapper.Map<DetalleOrdenDTO>(detalleOrdenEntity);
            }

            var response = new { Order = orderDto, DetalleOrden = detalleOrdenDto };
            return Ok(response);
        }

        [HttpGet("Order")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderServices.GetAll();
            var orderDtos = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return Ok(orderDtos);
        }

        private decimal CalculateTotalPrice(List<DetalleOrdenDTO> detalles, List<Producto> productos)
        {
            decimal totalPrice = 0;

            if (detalles != null && detalles.Any())
            {
                foreach (var detalle in detalles)
                {
                    var producto = productos.FirstOrDefault(p => p.IdProducto == detalle.ID_Producto);

                    if (producto != null)
                    {
                        totalPrice += detalle.Cantidad * producto.Precio;
                    }
                }
            }

            return totalPrice;
        }

        // [HttpGet("Order/{id:int}")]
        // public async Task<IActionResult> GetOrderById(int id)
        // {
        //     var order = await _orderServices.GetById(id);
        //     if (order == null)
        //         return NotFound();
        //     var detallez = await _detallesOrdenServices.GetByOrderId(id);
        //     // Obtiene los detalles de la orden correspondientes a la orden principal
        //     var detallesOrden = await _detallesOrdenServices.GetByOrderId(id);
        //     var orderDto = _mapper.Map<OrderDTO>(order);

        //     if (detallesOrden != null && detallesOrden.Any())
        //     {
        //         // Obtén la lista de ID_Producto de los detalles de la orden
        //         var idProductos = detallesOrden.Select(detalle => detalle.IdProducto).ToList();

        //         // Supongamos que tienes una función para cargar los productos por lista de ID_Producto
        //         var productos = await _productoServices.GetProductosById(idProductos);

        //         // Mapea los detalles de la orden a sus respectivos DTO
        //         var detallesOrdenDto = detallesOrden.Select(detalle => _mapper.Map<DetalleOrdenDTO>(detalle)).ToList();

        //         // Calcula el precio total de los detalles de la orden
        //         decimal totalPrice = CalculateTotalPrice(detallesOrdenDto, productos);

        //         // Crea una nueva instancia de DetalleOrdenDTO y establece el PrecioTotal
        //         var detalleDto = new DetalleOrdenDTO
        //         {
        //             PrecioTotal = totalPrice
        //         };

        //         // Agrega el detalle de orden calculado al principio de la lista
        //         detallesOrdenDto.Insert(1, detalleDto);
        //         // Asigna la lista de detalles ordenada al DTO de la orden
        //         orderDto.DetalleOrden = detallesOrdenDto;
        //     }

        //     return Ok(orderDto);
        // }

        [HttpGet("Order/{id:int}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderServices.GetById(id);
            if (order == null)
                return NotFound();

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
                orderDto.DetalleOrden = detallesOrdenDto;

                // Actualiza el precio total en el primer elemento de detallesOrdenDto
                if (detallesOrdenDto.Any())
                {
                    detallesOrdenDto.First().PrecioTotal = totalPrice;
                }
            }

            return Ok(orderDto);
        }



        [HttpDelete("Order/{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _detallesOrdenServices.DeleteByOrderId(id);
            await _orderServices.Delete(id);
            return NoContent();
        }

        [HttpGet("OrdenesPorCliente")]
        public async Task<IActionResult> GetOrdersByClienteId(int clienteId)
        {
            // Primero, verifica si el cliente existe
            var cliente = await _clienteServices.GetById(clienteId);
            if (cliente == null)
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
            var ordenes = await _orderServices.GetOrdersByClienteId(clienteId);

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
