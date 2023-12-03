using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;
namespace TostiElotes.Infrastructure.Repositories
{
    public class RepartidorRepository
    {
        
        private readonly SnackappDbContext _context;
        public RepartidorRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<IEnumerable<Repartidor>> GetAll()
        {
            var cliente = await _context.Repartidores.ToListAsync();
            return cliente;
        }
        public async Task<Repartidor> GetById(int id)
        {
            var cliente = await _context.Repartidores.FirstOrDefaultAsync(cliente => cliente.IdRepartidor == id);
            return cliente ?? new Repartidor();
        }
         public async Task<Repartidor> GetClienteByCorreoElectronico(string correo)
        {
            var cliente = await _context.Repartidores.FirstOrDefaultAsync(cliente => cliente.CorreoElectronico == correo);
            return cliente ?? new Repartidor();
        }
        public async Task Add(Repartidor ClienteDB)
        {
            await _context.Repartidores.AddAsync(ClienteDB);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Repartidor updatedClienteDB)
        {
            var ClienteDB = await _context.Repartidores.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdRepartidor == updatedClienteDB.IdRepartidor);

            if (ClienteDB != null)
            {
                _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ClienteDB = await _context.Repartidores.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdRepartidor == id);
            if (ClienteDB != null)
            {
                _context.Repartidores.Remove(ClienteDB);
                await _context.SaveChangesAsync();
            }
        }
    }
}