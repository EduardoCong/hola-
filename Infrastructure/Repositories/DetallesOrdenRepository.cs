using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;
namespace TostiElotes.Infrastructure.Repositories
{
    public class DetalleOrdenRepository
    {
        private readonly SnackappDbContext _context;

        public DetalleOrdenRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<DetalleOrden>> GetAll()
        {
            var detallesOrden = await _context.DetallesOrden.ToListAsync();
            return detallesOrden;
        }

        public async Task<DetalleOrden> GetById(int id)
        {
            var detalleOrden = await _context.DetallesOrden.FirstOrDefaultAsync(detalle => detalle.IdDetalle == id);
            return detalleOrden ?? new DetalleOrden();
        }

        public async Task Add(DetalleOrden detalleOrden)
        {
            await _context.DetallesOrden.AddAsync(detalleOrden);
            await _context.SaveChangesAsync();
        }

        public async Task Update(DetalleOrden updatedDetalleOrden)
        {
            var detalleOrden = await _context.DetallesOrden.FirstOrDefaultAsync(detalle => detalle.IdDetalle == updatedDetalleOrden.IdDetalle);
            if (detalleOrden != null)
            {
                _context.Entry(detalleOrden).CurrentValues.SetValues(updatedDetalleOrden);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var detalleOrden = await _context.DetallesOrden.FirstOrDefaultAsync(detalle => detalle.IdDetalle == id);
            if (detalleOrden != null)
            {
                _context.DetallesOrden.Remove(detalleOrden);
                await _context.SaveChangesAsync();
            }
        }
    }
}
