using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features;

public class ProductoServices
{
    private readonly ProductoRepository _productoRepository;

    public ProductoServices(ProductoRepository ProductoRepository)
    {
        this._productoRepository = ProductoRepository;
    }

    public async Task<IEnumerable<Producto>> GetAll()
    {
        return await _productoRepository.GetAll();
    }

    public async Task<Producto> GetById(int id)
    {
        return await _productoRepository.GetById(id);
    }

    public async Task Add(Producto producto)
    {
       await _productoRepository.Add(producto);
    }

    public async Task Update(Producto productoToUpdate)
    {
        var Producto = await GetById(productoToUpdate.IdProducto);

        if (Producto.IdProducto >= 0)
           await _productoRepository.Update(productoToUpdate);
    }

    public async Task Delete(int id)
    {
        var Producto = await GetById(id);
        if (Producto.IdProducto >= 0)
           await _productoRepository.Delete(id);
    }
}
