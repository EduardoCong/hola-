using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;

namespace TostiElotes.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DetallesOrdenController : ControllerBase
    {
        private readonly DetalleOrdenServices _detallesOrdenServices;
        private readonly IMapper _mapper;

        public DetallesOrdenController(DetalleOrdenServices detallesOrdenServices, IMapper mapper)
        {
            this._detallesOrdenServices = detallesOrdenServices ?? throw new ArgumentNullException(nameof(detallesOrdenServices));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var detallesOrden = await _detallesOrdenServices.GetAll();
            var detallesOrdenDtos = _mapper.Map<IEnumerable<DetalleOrdenDTO>>(detallesOrden);

            return Ok(detallesOrdenDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var detallesOrden = await _detallesOrdenServices.GetById(id);

            if (detallesOrden == null)
                return NotFound();

            var dto = _mapper.Map<DetalleOrdenDTO>(detallesOrden);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DetalleOrdenCreateDTO detallesOrden)
        {
            var entity = _mapper.Map<DetalleOrden>(detallesOrden);

            await _detallesOrdenServices.Add(entity);
            var dto = _mapper.Map<DetalleOrdenDTO>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.IdDetalle}, dto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, DetalleOrden detallesOrden)
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _detallesOrdenServices.Delete(id);
            return NoContent();
        }
    }
}
