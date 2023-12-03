using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;

namespace TostiElotes.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class PorductoController : ControllerBase
    {
        private readonly ProductoService _productoService;

        private readonly IMapper _mapper;

        public PorductoController(ProductoService productoService, IMapper mapper)
        {
            this._productoService = productoService ?? throw new ArgumentNullException(nameof(productoService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _productoService.GetAll();
            var clienteDtos = _mapper.Map<IEnumerable<ProductoDTO>>(clientes);

            return Ok(clienteDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _productoService.GetById(id);

            if (cliente.Id == 0)
                return BadRequest("No se encontro el usuario");

            var dto = _mapper.Map<ProductoDTO>(cliente);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductoCreateDTO cliente)
        {
            Console.WriteLine(ModelState.IsValid);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Obtener los bytes de la imagen a partir de la ruta proporcionada
            var imagenEnBytes = await _productoService.LeerImagenComoBytesAsync(cliente.ImagenProducto);

            // Crear una nueva instancia de Producto y asignar los valores
            Producto producto = new Producto
            {
                Categoria = cliente.Categoria,
                ClaveProducto = cliente.ClaveProducto,
                NombreProducto = cliente.NombreProducto,
                Descripcion = cliente.Descripcion,
                ImagenProducto = imagenEnBytes,
                Tamano = cliente.Tamano,
                Sabor = cliente.Sabor,
                Precio = cliente.Precio,
                Disponibilidad = cliente.Disponibilidad,
                PromocionesDescuentos = cliente.PromocionesDescuentos,
                IdPuesto = cliente.IdPuesto
            };

            // Llamar al servicio para agregar el producto
            await _productoService.Add(producto);

            // Mapear la entidad Producto a un DTO para la respuesta
            var dto = _mapper.Map<ProductoDTO>(producto);

            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, dto);

        }


        // [HttpPut("{id:int}")]
        // public async Task<IActionResult> Update(int id, [FromBody] ProductoCreateDTO cliente)
        // {
        //     if (cliente == null)
        //         return BadRequest("Producto no válido.");

        //     var existingCliente = await _productoService.GetById(id);

        //     if (existingCliente.Id == 0)
        //         return BadRequest("Producto no existente.");

        //     // Realiza el mapeo de cliente a existingCliente
        //     _mapper.Map(cliente, existingCliente);

        //     await _productoService.Update(existingCliente);

        //     // Opcional: mapea el cliente actualizado a DTO si es necesario
        //     var updatedClienteDto = _mapper.Map<ProductoDTO>(existingCliente);

        //     return Ok(updatedClienteDto);
        // }


        // [HttpDelete("{id:int}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var exstingCliente = await _productoService.GetById(id);
        //     if (exstingCliente.Id == 0)
        //         return BadRequest("Producto no existente.");

        //     await _productoService.Delete(id);
        //     return Ok("Producto eliminado correctamente");
        // }

    }
}
