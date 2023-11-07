using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;

namespace TostiElotes.Infrastructure.Repositories
{


    public class EstadoEntregaRepository
    {
        private readonly SnackappDbContext _context;

        public EstadoEntregaRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddEstadoEntrega(EstadoEntrega estadoEntrega)
        {
            await _context.EstadoEntrega.AddAsync(estadoEntrega);
            await _context.SaveChangesAsync();
        }

        public async Task<EstadoEntrega> GetEstadoEntregaByOrden(int idOrden)
        {
            var estadosEntrega = await _context.EstadoEntrega.FirstOrDefaultAsync(Orden => Orden.IdOrden == idOrden);

            return estadosEntrega ?? new EstadoEntrega();
        }
        public async Task<EstadoEntrega> GetById(int id)
        {
            var users = await _context.EstadoEntrega.FirstOrDefaultAsync(users => users.IdOrden == id);
            return users ?? new EstadoEntrega();
        }
        public async Task Update(EstadoEntrega estadoEntrega)
        {
            _context.Entry(estadoEntrega).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        

        public async Task<IEnumerable<EstadoEntrega>> GetAll()
        {
            var Estados = await _context.EstadoEntrega.ToListAsync();
            return Estados;
        }
    }
}


