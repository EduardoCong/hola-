using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;

namespace TostiElotes.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenController : ControllerBase
    {

        private readonly OrdenService _ordenservice;

        private readonly IMapper _mapper;

        public OrdenController(OrdenService ordenService, IMapper mapper)
        {
            this._ordenservice = ordenService ?? throw new ArgumentNullException(nameof(ordenService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _ordenservice.GetAll();
            var clienteDtos = _mapper.Map<IEnumerable<OrdenDTO>>(clientes);

            return Ok(clienteDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _ordenservice.GetById(id);

            if (cliente.IdOrden == 0)
                return BadRequest("No se encontro el usuario");

            var dto = _mapper.Map<OrdenDTO>(cliente);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OrdenCreateDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _mapper.Map<Orden>(cliente);

            await _ordenservice.Add(entity);
            var dto = _mapper.Map<OrdenDTO>(entity);

            // Ejecutar el procedimiento almacenado para actualizar el estado del carrito
            await _ordenservice.ActualizarEstadoCarrito(entity.IdCarrito, entity.Estado!);

            return CreatedAtAction(nameof(GetById), new { id = entity.IdOrden }, dto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrdenCreateDTO cliente)
        {
            if (cliente == null)
                return BadRequest("Orden no válido.");

            var existingCliente = await _ordenservice.GetById(id);

            if (existingCliente.IdOrden == 0)
                return BadRequest("Orden no existente.");

            // Realiza el mapeo de cliente a existingCliente
            _mapper.Map(cliente, existingCliente);

            await _ordenservice.Update(existingCliente);

            // Opcional: mapea el cliente actualizado a DTO si es necesario
            var updatedClienteDto = _mapper.Map<OrdenDTO>(existingCliente);

            return Ok(updatedClienteDto);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exstingCliente = await _ordenservice.GetById(id);
            if (exstingCliente.IdOrden == 0)
                return BadRequest("Orden no existente.");

            await _ordenservice.Delete(id);
            return Ok("Orden eliminado correctamente");
        }

    }
}
