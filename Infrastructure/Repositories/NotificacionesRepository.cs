using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;

namespace TostiElotes.Infrastructure.Repositories
{
    public class NotificacionesRepository
    {
        
        private readonly SnackappDbContext _context;
        public NotificacionesRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<IEnumerable<Notificacione>> GetAll()
        {
            var notificacion = await _context.Notificaciones.ToListAsync();
            return notificacion;
        }
        public async Task<Notificacione> GetById(int id)
        {
            var notificacion = await _context.Notificaciones.FirstOrDefaultAsync(notificacion => notificacion.IdNotificacion == id);
            return notificacion ?? new Notificacione();
        }
        public async Task Add(Notificacione ClienteDB)
        {
            await _context.Notificaciones.AddAsync(ClienteDB);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Notificacione updatedClienteDB)
        {
            var ClienteDB = await _context.Notificaciones.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdNotificacion == updatedClienteDB.IdNotificacion);

            if (ClienteDB != null)
            {
                _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ClienteDB = await _context.Notificaciones.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdNotificacion == id);
            if (ClienteDB != null)
            {
                _context.Notificaciones.Remove(ClienteDB);
                await _context.SaveChangesAsync();
            }
        }
    }
}