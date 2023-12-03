using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;


namespace TostiElotes.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoController : ControllerBase
    {
        private readonly DetalleCarritoService _detalleService;

        private readonly CarritoService _carritoService;

        private readonly IMapper _mapper;

        public CarritoController(CarritoService carritoService, DetalleCarritoService detalleCarritoService, IMapper mapper)
        {
            this._carritoService = carritoService ?? throw new ArgumentNullException(nameof(carritoService));
            this._detalleService = detalleCarritoService ?? throw new ArgumentNullException(nameof(detalleCarritoService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _carritoService.GetAll();
            var clienteDtos = _mapper.Map<IEnumerable<CarritoDTO>>(clientes);

            return Ok(clienteDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _carritoService.GetById(id);

            if (cliente.IdCliente == 0)
                return BadRequest("No se encontro el usuario");

            var dto = _mapper.Map<CarritoDTO>(cliente);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CarritoCreateDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _mapper.Map<CarritoDeCompra>(cliente);
            entity.Estado = "Nuevo";
            await _carritoService.Add(entity);
            var dto = _mapper.Map<CarritoDTO>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.IdCliente }, dto);
        }


         [HttpGet("Detallesorden")]
        public async Task<IActionResult> GetAllDetalles()
        {
            var clientes = await _detalleService.GetAll();
            var clienteDtos = _mapper.Map<IEnumerable<DetallesCarritoDTO>>(clientes);

            return Ok(clienteDtos);
        }

        [HttpGet("Detallesorden/{id:int}")]
        public async Task<IActionResult> GetByIdDetalles(int id)
        {
            var cliente = await _detalleService.GetById(id);

            if (cliente.IdDetalle == 0)
                return BadRequest("No se encontro el usuario");

            var dto = _mapper.Map<DetallesCarritoDTO>(cliente);

            return Ok(dto);
        }

       [HttpPost("Detallesorden")]
        public async Task<IActionResult> Add([FromBody] DetallesCarritoCreateDTO cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = _mapper.Map<DetalleCarrito>(cliente);

            await _detalleService.Add(entity);
            var dto = _mapper.Map<DetallesCarritoDTO>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.IdDetalle }, dto);
        }

    }
}
