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

        if (producto.IdProducto == 0)
            return BadRequest("El producto no Existe.");

        var dto = _mapper.Map<ProductoDTO>(producto);

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductoCreateDTO producto)
    {
        var entity = _mapper.Map<Producto>(producto);

        await _productoServices.Add(entity);


        var dto = _mapper.Map<ProductoDTO>(entity);

        return CreatedAtAction(nameof(GetById), new { id = dto.ID_Producto }, dto);
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, ProductoCreateDTO producto)
    {
        if (producto == null)
            return BadRequest("producto no válido.");

        var existingproducto = await _productoServices.GetById(id);

        if (existingproducto.IdProducto == 0)
            return BadRequest("El producto no Existe.");

        // Realiza el mapeo de producto a existingproducto
        _mapper.Map(producto, existingproducto);

        await _productoServices.Update(existingproducto);

        // Opcional: mapea el producto actualizado a DTO si es necesario
        var updatedproductoDto = _mapper.Map<ProductoDTO>(existingproducto);

        return Ok(updatedproductoDto);
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var exstingCliente = await _productoServices.GetById(id);
        if (exstingCliente.IdProducto == 0)
            return BadRequest("El producto no existente.");

        await _productoServices.Delete(id);
        return Ok("El producto eliminado correctamente");
    }
}