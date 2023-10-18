using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;
namespace TostiElotes.Infrastructure.Repositories
{
    public class OrdenRepository
    {
        private readonly SnackappDbContext _context;
        public OrdenRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Orden>> GetAll()
        {
            var ordenes = await _context.Orden.ToListAsync();
            return ordenes;
        }
        public async Task<Orden> GetById(int id)
        {
            var Ordens = await _context.Orden.FirstOrDefaultAsync(Orden => Orden.IdOrden == id);
            return Ordens ?? new Orden();
        }
        public async Task Add(Orden Ordens)
        {
            await _context.Orden.AddAsync(Ordens);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Orden updatedOrden)
        {
            var orden = await _context.Orden.FirstOrDefaultAsync(orden => orden.IdOrden == updatedOrden.IdOrden);
            if (orden != null)
            {
                _context.Entry(orden).CurrentValues.SetValues(updatedOrden);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var Orden = await _context.Orden.FirstOrDefaultAsync(Orden => Orden.IdOrden == id);
            if (Orden != null)
            {
                _context.Orden.Remove(Orden);
                await _context.SaveChangesAsync();
            }
        }
    }
}