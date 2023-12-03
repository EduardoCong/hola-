using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;

namespace TostiElotes.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuestoController : ControllerBase
    {
        
        private readonly PuestoNegocioService _puestoService;

        private readonly IMapper _mapper;

        public PuestoController(PuestoNegocioService puestoNegocioService, IMapper mapper)
        {
            this._puestoService = puestoNegocioService ?? throw new ArgumentNullException(nameof (puestoNegocioService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _puestoService.GetAll();
            var clienteDtos = _mapper.Map<IEnumerable<PuestoNegocioDTO>>(clientes);

            return Ok(clienteDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _puestoService.GetById(id);

            if (cliente.Id == 0)
                return BadRequest("No se encontro el Puesto");

            var dto = _mapper.Map<PuestoNegocioDTO>(cliente);

            return Ok(dto);
        }
        // [HttpGet("{correo}")]
        // public async Task<IActionResult> GetClienteByCorreoElectronico(string correo)
        // {
        //     try
        //     {
        //         var cliente = await CorreoElectronicoExists(correo);

        //         if (cliente.Id == 0)
        //             return NotFound($"No se encontró ningún cliente con el correo electrónico {correo}");

        //         var dto = _mapper.Map<PuestoNegocioDTO>(cliente);

        //         return Ok(dto);
        //     }
        //     catch (Exception)
        //     {
        //         // Log the exception
        //         return StatusCode(500, "Error interno del servidor");
        //     }
        // }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PuestoNegocioCreateDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _mapper.Map<PuestosNegocio>(cliente);

            await _puestoService.Add(entity);
            var dto = _mapper.Map<PuestoNegocioDTO>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] PuestoNegocioCreateDTO cliente)
        {
            if (cliente == null)
                return BadRequest("El Puesto no es válido.");

            var existingCliente = await _puestoService.GetById(id);

            if (existingCliente.Id == 0)
                return BadRequest("El Puesto no existente.");

            // Realiza el mapeo de cliente a existingCliente
            _mapper.Map(cliente, existingCliente);

            await _puestoService.Update(existingCliente);

            // Opcional: mapea el cliente actualizado a DTO si es necesario
            var updatedClienteDto = _mapper.Map<PuestoNegocioDTO>(existingCliente);

            return Ok(updatedClienteDto);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exstingCliente = await _puestoService.GetById(id);
            if (exstingCliente.Id == 0)
                return BadRequest("El Puesto no existente.");

            await _puestoService.Delete(id);
            return Ok("El Puesto eliminado correctamente");
        }
    }
}