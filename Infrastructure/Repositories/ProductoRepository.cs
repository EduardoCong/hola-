using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;

namespace TostiElotes.Infrastructure.Repositories
{
    public class ProductoRepository
    {
        private readonly ContexdataDB _context;
        public ProductoRepository(ContexdataDB context)
        {
            this._context = context  ?? throw new ArgumentNullException(nameof(context));;
        }
        public async Task<IEnumerable<Producto>> GetAll()
        {
            var productos = await _context.Productos.ToListAsync();
            return productos;
        }
        public  async Task<Producto> GetById(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(product => product.Id == id);
            return producto ?? new Producto();
        }
        public async Task Add(Producto producto)
        {
            await _context.AddAsync(producto);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Producto updatedProducto)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(producto => producto.Id == updatedProducto.Id);
            if (producto != null){
                _context.Entry(producto).CurrentValues.SetValues(updatedProducto);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(producto => producto.Id == id);
           if(producto != null){
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
           }
        }
    }
}