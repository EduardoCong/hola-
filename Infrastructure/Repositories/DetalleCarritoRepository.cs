using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;
namespace TostiElotes.Infrastructure.Repositories
{
    public class DetalleCarritoRepository
    {
        
        private readonly SnackappDbContext _context;
        public DetalleCarritoRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<IEnumerable<DetalleCarrito>> GetAll()
        {
            var detalle = await _context.DetalleCarrito.ToListAsync();
            return detalle;
        }
        public async Task<DetalleCarrito> GetById(int id)
        {
            var detalle = await _context.DetalleCarrito.FirstOrDefaultAsync(detalle => detalle.IdDetalle == id);
            return detalle ?? new DetalleCarrito();
        }
        public async Task Add(DetalleCarrito detalleBD)
        {
            await _context.DetalleCarrito.AddAsync(detalleBD);
            await _context.SaveChangesAsync();
        }
        public async Task Update(DetalleCarrito updatedClienteDB)
        {
            var detalleBD = await _context.DetalleCarrito.FirstOrDefaultAsync(detalleBD => detalleBD.IdDetalle == updatedClienteDB.IdDetalle);

            if (detalleBD != null)
            {
                _context.Entry(detalleBD).CurrentValues.SetValues(updatedClienteDB);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var detalleBD = await _context.DetalleCarrito.FirstOrDefaultAsync(detalleBD => detalleBD.IdDetalle == id);
            if (detalleBD != null)
            {
                _context.DetalleCarrito.Remove(detalleBD);
                await _context.SaveChangesAsync();
            }
        }
    }
}