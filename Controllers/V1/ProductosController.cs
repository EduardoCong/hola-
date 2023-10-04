using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;
using TostiElotes.Domain.Dtos;

namespace TostiElotes.Controllers.V1;
[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly ProductoServices _productoServices;
     private readonly IMapper _mapper;
    public ProductosController(ProductoServices productoServices, IMapper mapper)
    {
        this._productoServices = productoServices ?? throw new ArgumentNullException(nameof(productoServices));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var producto = await _productoServices.GetAll();
        var productoDtos = _mapper.Map<IEnumerable<ProductoDTO>>(producto); 
        
        return Ok(productoDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
         var producto = await _productoServices.GetById(id);

        if (producto == null)
            return NotFound();

        var dto = _mapper.Map<ProductoDTO>(producto); 

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductoCreateDTO producto)
  {
      var entity = _mapper.Map<Producto>(producto);

      await _productoServices.Add(entity);
      var dto = _mapper.Map<ProductoDTO>(entity);
      return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
  }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Producto producto)
    {
            if (id != producto.Id)
                return BadRequest();

            var existingProducto = await _productoServices.GetById(id);

            if (existingProducto == null)
                return NotFound();

            _mapper.Map(producto, existingProducto);

            await _productoServices.Update(existingProducto);

            var updatedProducto = await _productoServices.GetById(id);
            var updatedProductoDto = _mapper.Map<ProductoDTO>(updatedProducto);

            return Ok(updatedProductoDto);
        }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _productoServices.Delete(id);
        return NoContent();
    }
}