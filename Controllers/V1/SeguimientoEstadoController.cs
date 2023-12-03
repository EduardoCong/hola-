using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;

namespace TostiElotes.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguimientoEstadoController : ControllerBase
    {
        private readonly SeguimientoEstadoService _seguimientoServce;

        private readonly IMapper _mapper;

        public SeguimientoEstadoController(SeguimientoEstadoService seguimientoEstado, IMapper mapper)
        {
            this._seguimientoServce = seguimientoEstado ?? throw new ArgumentNullException(nameof(seguimientoEstado));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _seguimientoServce.GetAll();
            var clienteDtos = _mapper.Map<IEnumerable<SeguimientoEstadoDTO>>(clientes);

            return Ok(clienteDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _seguimientoServce.GetById(id);

            if (cliente.IdSeguimiento == 0)
                return BadRequest("No se encontro el usuario");

            var dto = _mapper.Map<SeguimientoEstadoDTO>(cliente);

            return Ok(dto);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SeguimientoEstadoCreateDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var entity = _mapper.Map<SeguimientoEstado>(cliente);

            await _seguimientoServce.Add(entity);
            var dto = _mapper.Map<SeguimientoEstadoDTO>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.IdSeguimiento }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar(int Carrito, string estado)
        {
            await _seguimientoServce.ActualizarEstadoCarrito(Carrito, estado);

            return NoContent(); // Devuelve un 204 No Content después de una operación de actualización exitosa.
        }
    }
}
