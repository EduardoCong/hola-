using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;

namespace TostiElotes.Infrastructure.Repositories
{
    public class VendedorProductoRepository
    {

        private readonly SnackappDbContext _context;
        public VendedorProductoRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<IEnumerable<VendedoresProducto>> GetAll()
        {
            var cliente = await _context.VendedoresProductos.ToListAsync();
            return cliente;
        }
        public async Task<VendedoresProducto> GetById(int id)
        {
            var cliente = await _context.VendedoresProductos.FirstOrDefaultAsync(cliente => cliente.IdVendedorProducto == id);
            return cliente ?? new VendedoresProducto();
        }
        public async Task<IEnumerable<VendedoresProducto>> GetProductoByIdVendedorAsync(int idVendedor)
        {
            return await _context.VendedoresProductos
                .Where(cliente => cliente.IdPuesto == idVendedor)
                .ToListAsync();
        }
        public async Task Add(VendedoresProducto ClienteDB)
        {
            await _context.VendedoresProductos.AddAsync(ClienteDB);
            await _context.SaveChangesAsync();
        }
        public async Task Update(VendedoresProducto updatedClienteDB)
        {
            var ClienteDB = await _context.VendedoresProductos.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdVendedorProducto == updatedClienteDB.IdVendedorProducto);

            if (ClienteDB != null)
            {
                _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ClienteDB = await _context.VendedoresProductos.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdVendedorProducto == id);
            if (ClienteDB != null)
            {
                _context.VendedoresProductos.Remove(ClienteDB);
                await _context.SaveChangesAsync();
            }
        }
    }
}