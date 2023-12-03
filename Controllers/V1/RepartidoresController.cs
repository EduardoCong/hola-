using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;

namespace TostiElotes.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepartidoresController : ControllerBase
    {
        private readonly RepartidorService _repartidorService;

        private readonly IMapper _mapper;

        public RepartidoresController(RepartidorService repartidorService, IMapper mapper)
        {
            this._repartidorService = repartidorService ?? throw new ArgumentNullException(nameof(repartidorService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _repartidorService.GetAll();
            var clienteDtos = _mapper.Map<IEnumerable<RepartidorDTO>>(clientes);

            return Ok(clienteDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _repartidorService.GetById(id);

            if (cliente.IdRepartidor == 0)
                return BadRequest("No se encontro el usuario");

            var dto = _mapper.Map<RepartidorDTO>(cliente);

            return Ok(dto);
        }

        // [HttpGet("{correo}")]
        // public async Task<IActionResult> GetClienteByCorreoElectronico(string correo)
        // {
        //     try
        //     {
        //         var cliente = await CorreoElectronicoExists(correo);

        //         if (cliente.IdRepartidor == 0)
        //             return NotFound($"No se encontró ningún cliente con el correo electrónico {correo}");

        //         var dto = _mapper.Map<RepartidorDTO>(cliente);

        //         return Ok(dto);
        //     }
        //     catch (Exception)
        //     {
        //         // Log the exception
        //         return StatusCode(500, "Error interno del servidor");
        //     }
        // }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RepartidorCreateDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validar que el correo electrónico no exista en la base de datos
            var clienteExist = await CorreoElectronicoExists(cliente.CorreoElectronico);
            if (clienteExist.IdRepartidor != 0)
            {
                ModelState.AddModelError("CorreoElectronico", "El correo electrónico ya está registrado.");
                return BadRequest(ModelState);
            }

            var entity = _mapper.Map<Repartidor>(cliente);

            await _repartidorService.Add(entity);
            var dto = _mapper.Map<RepartidorDTO>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.IdRepartidor }, dto);
        }

        private async Task<Repartidor> CorreoElectronicoExists(string correoElectronico)
        {
            var clienteExistente = await _repartidorService.GetClienteByCorreoElectronico(correoElectronico);
            return clienteExistente;
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] RepartidorCreateDTO cliente)
        {
            if (cliente == null)
                return BadRequest("Repartidor no válido.");

            var existingCliente = await _repartidorService.GetById(id);

            if (existingCliente.IdRepartidor == 0)
                return BadRequest("Repartidor no existente.");

            // Realiza el mapeo de cliente a existingCliente
            _mapper.Map(cliente, existingCliente);

            await _repartidorService.Update(existingCliente);

            // Opcional: mapea el cliente actualizado a DTO si es necesario
            var updatedClienteDto = _mapper.Map<RepartidorDTO>(existingCliente);

            return Ok(updatedClienteDto);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exstingCliente = await _repartidorService.GetById(id);
            if (exstingCliente.IdRepartidor == 0)
                return BadRequest("Repartidor no existente.");

            await _repartidorService.Delete(id);
            return Ok("Repartidor eliminado correctamente");
        }

    }
}


/*

// Clientes;
// Vendedores;
// Repartidores;
// PuestosNegocios;
// Vendedores_Puestos;
// Productos;
// Vendedores_Productos;
DetalleCarrito; 
CarritoDeCompras;
Ordenes;
SeguimientoEstado;*/
