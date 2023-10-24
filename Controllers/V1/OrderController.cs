using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TostiElotes.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdenController : ControllerBase
    {
        private readonly OrdenServices _orderServices;
        private readonly DetalleOrdenServices _detallesOrdenServices;
        private readonly IMapper _mapper;

        public OrdenController(OrdenServices orderServices, DetalleOrdenServices detallesOrdenServices, IMapper mapper)
        {
            _orderServices = orderServices ?? throw new ArgumentNullException(nameof(orderServices));
            _detallesOrdenServices = detallesOrdenServices ?? throw new ArgumentNullException(nameof(detallesOrdenServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Métodos para manejar órdenes
        [HttpGet("Order")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderServices.GetAll();
            var orderDtos = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return Ok(orderDtos);
        }

        [HttpGet("Order/{id:int}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderServices.GetById(id);
            if (order == null)
                return NotFound();
            var dto = _mapper.Map<OrderDTO>(order);
            return Ok(dto);
        }

        [HttpPost("Order")]
        public async Task<IActionResult> AddOrder(OrderCreateDTO order)
        {
            var entity = _mapper.Map<Orden>(order);
            await _orderServices.Add(entity);
            var dto = _mapper.Map<OrderDTO>(entity);

            // Agregar los detalles de la orden
            if (order.DetalleOrden != null && order.DetalleOrden.Any())
            {
                var detallesOrdenEntities = _mapper.Map<List<DetalleOrden>>(order.DetalleOrden);
                foreach (var detalleEntity in detallesOrdenEntities)
                {
                    detalleEntity.IdOrden = entity.IdOrden; // Asigna el ID de la orden
                    await _detallesOrdenServices.Add(detalleEntity);
                }
            }

            return CreatedAtAction(nameof(GetOrderById), new { id = entity.IdOrden }, dto);
        }

        [HttpPut("Order/{id:int}")]
        public async Task<IActionResult> UpdateOrder(int id, Orden order)
        {
            if (id != order.IdOrden)
                return BadRequest();

            var existingOrder = await _orderServices.GetById(id);

            if (existingOrder == null)
                return NotFound();

            _mapper.Map(order, existingOrder);

            await _orderServices.Update(existingOrder);

            var updatedOrder = await _orderServices.GetById(id);
            var updatedOrderDto = _mapper.Map<OrderDTO>(updatedOrder);

            return Ok(updatedOrderDto);
        }

        [HttpDelete("Order/{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderServices.Delete(id);
            return NoContent();
        }

        // Métodos para manejar detalles de órdenes
        [HttpGet("DetallesOrden")]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            var detallesOrden = await _detallesOrdenServices.GetAll();
            var detallesOrdenDtos = _mapper.Map<IEnumerable<DetalleOrdenDTO>>(detallesOrden);
            return Ok(detallesOrdenDtos);
        }

        [HttpGet("DetallesOrden/{id:int}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var detallesOrden = await _detallesOrdenServices.GetById(id);
            if (detallesOrden == null)
                return NotFound();
            var dto = _mapper.Map<DetalleOrdenDTO>(detallesOrden);
            return Ok(dto);
        }

        [HttpPost("DetallesOrden")]
        public async Task<IActionResult> AddOrderDetail(OrderCreateDTO detallesOrden)
        {
            try
            {
                var entity = _mapper.Map<DetalleOrden>(detallesOrden);
                await _detallesOrdenServices.Add(entity);
                var dto = _mapper.Map<DetalleOrdenDTO>(entity);
                return CreatedAtAction(nameof(GetOrderDetailById), new { id = dto.ID_Detalle }, dto);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocurrió un error al agregar el detalle de orden: " + ex.Message);
            }
        }

        [HttpPut("DetallesOrden/{id:int}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, DetalleOrden detallesOrden)
        {
            if (id != detallesOrden.IdDetalle)
                return BadRequest();

            var existingDetallesOrden = await _detallesOrdenServices.GetById(id);

            if (existingDetallesOrden == null)
                return NotFound();

            _mapper.Map(detallesOrden, existingDetallesOrden);

            await _detallesOrdenServices.Update(existingDetallesOrden);

            var updatedDetallesOrden = await _detallesOrdenServices.GetById(id);
            var updatedDetallesOrdenDto = _mapper.Map<DetalleOrdenDTO>(updatedDetallesOrden);

            return Ok(updatedDetallesOrdenDto);
        }

        [HttpDelete("DetallesOrden/{id:int}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _detallesOrdenServices.Delete(id);
            return NoContent();
        }
    }
}
