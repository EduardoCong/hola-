using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;

namespace TostiElotes.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorController : ControllerBase
    {

        private readonly VendedorService _vendedorServices;
        private readonly VendedorPuestoService _vendedorPuestoService;
        private readonly VendedoProductoService _vendedoProductoService;

        private readonly IMapper _mapper;

        public VendedorController(VendedorService vendedorServices, VendedorPuestoService vendedorPuestoService, VendedoProductoService vendedoProductoService, IMapper mapper)
        {
            this._vendedorServices = vendedorServices ?? throw new ArgumentNullException(nameof(vendedorServices));
            this._vendedorPuestoService = vendedorPuestoService ?? throw new ArgumentNullException(nameof(vendedorPuestoService));
            this._vendedoProductoService = vendedoProductoService ?? throw new ArgumentNullException(nameof(vendedoProductoService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _vendedorServices.GetAll();
            var clienteDtos = _mapper.Map<IEnumerable<VendedorDTO>>(clientes);

            return Ok(clienteDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _vendedorServices.GetById(id);

            if (cliente.IdVendedor == 0)
                return BadRequest("No se encontro el usuario");

            var dto = _mapper.Map<VendedorDTO>(cliente);

            return Ok(dto);
        }
        // [HttpGet("{correo}")]
        // public async Task<IActionResult> GetVendedorByCorreoElectronico(string correo)
        // {
        //     try
        //     {
        //         var cliente = await CorreoElectronicoExists(correo);

        //         if (cliente.IdVendedor == 0)
        //             return NotFound($"No se encontró ningún cliente con el correo electrónico {correo}");

        //         var dto = _mapper.Map<VendedorDTO>(cliente);

        //         return Ok(dto);
        //     }
        //     catch (Exception)
        //     {
        //         // Log the exception
        //         return StatusCode(500, "Error interno del servidor");
        //     }
        // }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] VendedorCreateDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validar que el correo electrónico no exista en la base de datos
            var clienteExist = await CorreoElectronicoExists(cliente.CorreoElectronico);
            if (clienteExist.IdVendedor != 0)
            {
                ModelState.AddModelError("CorreoElectronico", "El correo electrónico ya está registrado.");
                return BadRequest(ModelState);
            }

            var entity = _mapper.Map<Vendedor>(cliente);

            await _vendedorServices.Add(entity);
            var dto = _mapper.Map<VendedorDTO>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.IdVendedor }, dto);
        }

        private async Task<Vendedor> CorreoElectronicoExists(string correoElectronico)
        {
            var clienteExistente = await _vendedorServices.GetVendedorByCorreoElectronico(correoElectronico);
            return clienteExistente;
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] VendedorCreateDTO cliente)
        {
            if (cliente == null)
                return BadRequest("Vendedor no válido.");

            var existingCliente = await _vendedorServices.GetById(id);

            if (existingCliente.IdVendedor == 0)
                return BadRequest("Vendedor no existente.");

            // Realiza el mapeo de cliente a existingCliente
            _mapper.Map(cliente, existingCliente);

            await _vendedorServices.Update(existingCliente);

            // Opcional: mapea el cliente actualizado a DTO si es necesario
            var updatedClienteDto = _mapper.Map<VendedorDTO>(existingCliente);

            return Ok(updatedClienteDto);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exstingCliente = await _vendedorServices.GetById(id);
            if (exstingCliente.IdVendedor == 0)
                return BadRequest("Vendedor no existente.");

            await _vendedorServices.Delete(id);
            return Ok("Vendedor eliminado correctamente");
        }

        [HttpGet("Existe/Puesto/{id:int}")]
        public async Task<ActionResult> GetPuestoById(int id)
        {
            var vendedorPuesto = await _vendedorPuestoService.GetById(id);

            if (vendedorPuesto.IdRelacion == 0)
            {
                return BadRequest("No se encontró el Puesto");
            }

            var dto = _mapper.Map<VendedorPuestoDTO>(vendedorPuesto);

            return Ok(dto);
        }

        [HttpGet("ByVendedorId/{id_vendedor:int}")]
        public async Task<ActionResult> GetPuestoByIdVendedorAsync(int id_vendedor)
        {
            var puestos = await _vendedorPuestoService.GetPuestosByIdVendedorAsync(id_vendedor);

            if (puestos == null || !puestos.Any())
            {
                return BadRequest($"No se encontró puesto con el ID {id_vendedor}");
            }

            var dtos = _mapper.Map<List<VendedorPuestoDTO>>(puestos);
            return Ok(dtos);
        }

         [HttpGet("Existe/Producto/{id:int}")]
        public async Task<ActionResult> GetProductoById(int id)
        {
            var vendedorPuesto = await _vendedoProductoService.GetById(id);

            if (vendedorPuesto.IdVendedorProducto == 0)
            {
                return BadRequest("No se encontró el Producto");
            }

            var dto = _mapper.Map<VendedorProductoDTO>(vendedorPuesto);

            return Ok(dto);
        }

        [HttpGet("ProductosByVendedorId/{id_vendedor:int}")]
        public async Task<ActionResult> GetProductosByIdVendedorAsync(int id_vendedor)
        {
            var puestos = await _vendedoProductoService.GetPuestosByIdVendedorAsync(id_vendedor);

            if (puestos == null || !puestos.Any())
            {
                return BadRequest($"No se encontró puesto con el ID {id_vendedor}");
            }

            var dtos = _mapper.Map<List<VendedorProductoDTO>>(puestos);
            return Ok(dtos);
        }
    }
}
