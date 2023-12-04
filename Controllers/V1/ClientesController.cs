using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;

namespace TostiElotes.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {

        private readonly ClienteService _clienteServices;

        private readonly IMapper _mapper;

        public ClientesController(ClienteService clienteServices, IMapper mapper)
        {
            this._clienteServices = clienteServices ?? throw new ArgumentNullException(nameof(clienteServices));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteServices.GetAll();
            var clienteDtos = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);

            return Ok(clienteDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteServices.GetById(id);

            if (cliente.IdCliente == 0)
                return BadRequest("No se encontro el usuario");
            if (cliente.IdCliente == 0)
                return BadRequest("No se encontro el usuario");

            var dto = _mapper.Map<ClienteDTO>(cliente);

            return Ok(dto);
        }
        // [HttpGet("{correo}")]
        // public async Task<IActionResult> GetClienteByCorreoElectronico(string correo)
        // {
        //     try
        //     {
        //         var cliente = await CorreoElectronicoExists(correo);

        //         if (cliente.IdCliente == 0)
        //             return NotFound($"No se encontró ningún cliente con el correo electrónico {correo}");

        //         var dto = _mapper.Map<ClienteDTO>(cliente);

        //         return Ok(dto);
        //     }
        //     catch (Exception)
        //     {
        //         // Log the exception
        //         return StatusCode(500, "Error interno del servidor");
        //     }
        // }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ClienteCreateDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validar que el correo electrónico no exista en la base de datos
            var clienteExist = await CorreoElectronicoExists(cliente.CorreoElectronico);
            if (clienteExist.IdCliente != 0)
            {
                ModelState.AddModelError("CorreoElectronico", "El correo electrónico ya está registrado.");
                return BadRequest(ModelState);
            }

            var entity = _mapper.Map<Cliente>(cliente);

            await _clienteServices.Add(entity);
            var dto = _mapper.Map<ClienteDTO>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.IdCliente }, dto);
        }

        private async Task<Cliente> CorreoElectronicoExists(string correoElectronico)
        {
            var clienteExistente = await _clienteServices.GetClienteByCorreoElectronico(correoElectronico);
            return clienteExistente;
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteCreateDTO cliente)
        {
            if (cliente == null)
                return BadRequest("Cliente no válido.");

            var existingCliente = await _clienteServices.GetById(id);

            if (existingCliente.IdCliente == 0)
                return BadRequest("Cliente no existente.");

            // Realiza el mapeo de cliente a existingCliente
            _mapper.Map(cliente, existingCliente);

            await _clienteServices.Update(existingCliente);

            // Opcional: mapea el cliente actualizado a DTO si es necesario
            var updatedClienteDto = _mapper.Map<ClienteDTO>(existingCliente);

            return Ok(updatedClienteDto);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exstingCliente = await _clienteServices.GetById(id);
            if (exstingCliente.IdCliente == 0)
                return BadRequest("Cliente no existente.");

            await _clienteServices.Delete(id);
            return Ok("Cliente eliminado correctamente");
        }

    }
}
