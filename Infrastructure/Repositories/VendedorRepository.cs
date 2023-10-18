using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;

namespace TostiElotes.Infrastructure.Repositories
{
    public class VendedorRepository
    {
        private readonly SnackappDbContext _context;

        public VendedorRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Vendedor>> GetAll()
        {
            var vendedores = await _context.Vendedores.ToListAsync();
            return vendedores;
        }

        public async Task<Vendedor> GetById(int id)
        {
            var vendedor = await _context.Vendedores.FirstOrDefaultAsync(vendedor => vendedor.IdVendedor == id);
            return vendedor ?? new Vendedor();
        }

        public async Task Add(Vendedor vendedor)
        {
            await _context.Vendedores.AddAsync(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Vendedor updatedVendedor)
        {
            var vendedor = await _context.Vendedores.FirstOrDefaultAsync(vendedor => vendedor.IdVendedor == updatedVendedor.IdVendedor);
            if (vendedor != null)
            {
                _context.Entry(vendedor).CurrentValues.SetValues(updatedVendedor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var vendedor = await _context.Vendedores.FirstOrDefaultAsync(vendedor => vendedor.IdVendedor == id);
            if (vendedor != null)
            {
                _context.Vendedores.Remove(vendedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
