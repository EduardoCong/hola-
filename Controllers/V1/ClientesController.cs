using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;


namespace TostiElotes.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteServices _clienteServices;

        private readonly IMapper _mapper;

        public ClientesController(ClienteServices clienteServices, IMapper mapper)
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

            var dto = _mapper.Map<ClienteDTO>(cliente);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClienteCreateDTO cliente)
        {
            var entity = _mapper.Map<Cliente>(cliente);

            await _clienteServices.Add(entity);
            var dto = _mapper.Map<ClienteDTO>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.IdCliente }, dto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ClienteCreateDTO cliente)
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
            return Ok("Cliente eliminado correctamente" );
        }

    }
}
