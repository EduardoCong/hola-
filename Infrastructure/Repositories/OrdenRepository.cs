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
            var cliente = await _context.Ordenes.ToListAsync();
            return cliente;
        }
        public async Task<Orden> GetById(int id)
        {
            var cliente = await _context.Ordenes.FirstOrDefaultAsync(cliente => cliente.IdOrden == id);
            return cliente ?? new Orden();
        }
        public async Task Add(Orden ClienteDB)
        {
            await _context.Ordenes.AddAsync(ClienteDB);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Orden updatedClienteDB)
        {
            var ClienteDB = await _context.Ordenes.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdOrden == updatedClienteDB.IdOrden);

            if (ClienteDB != null)
            {
                _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ClienteDB = await _context.Ordenes.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdOrden == id);
            if (ClienteDB != null)
            {
                _context.Ordenes.Remove(ClienteDB);
                await _context.SaveChangesAsync();
            }
        }
    }
}