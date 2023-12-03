using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;

namespace TostiElotes.Infrastructure.Repositories
{
    public class SeguimientoEstadoRepository
    {
        
        private readonly SnackappDbContext _context;
        public SeguimientoEstadoRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<IEnumerable<SeguimientoEstado>> GetAll()
        {
            var cliente = await _context.SeguimientoEstado.ToListAsync();
            return cliente;
        }
        public async Task<SeguimientoEstado> GetById(int id)
        {
            var cliente = await _context.SeguimientoEstado.FirstOrDefaultAsync(cliente => cliente.IdSeguimiento == id);
            return cliente ?? new SeguimientoEstado();
        }
        public async Task Add(SeguimientoEstado ClienteDB)
        {
            await _context.SeguimientoEstado.AddAsync(ClienteDB);
            await _context.SaveChangesAsync();
        }
        public async Task Update(SeguimientoEstado updatedClienteDB)
        {
            var ClienteDB = await _context.SeguimientoEstado.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdSeguimiento == updatedClienteDB.IdSeguimiento);

            if (ClienteDB != null)
            {
                _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ClienteDB = await _context.SeguimientoEstado.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdSeguimiento == id);
            if (ClienteDB != null)
            {
                _context.SeguimientoEstado.Remove(ClienteDB);
                await _context.SaveChangesAsync();
            }
        }
    }
}