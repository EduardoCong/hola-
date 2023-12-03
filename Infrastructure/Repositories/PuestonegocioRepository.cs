using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;
namespace TostiElotes.Infrastructure.Repositories
{
    public class PuestonegocioRepository
    {
        
        private readonly SnackappDbContext _context;
        public PuestonegocioRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<IEnumerable<PuestosNegocio>> GetAll()
        {
            var cliente = await _context.PuestosNegocios.ToListAsync();
            return cliente;
        }
        public async Task<PuestosNegocio> GetById(int id)
        {
            var cliente = await _context.PuestosNegocios.FirstOrDefaultAsync(cliente => cliente.Id == id);
            return cliente ?? new PuestosNegocio();
        }
        public async Task Add(PuestosNegocio ClienteDB)
        {
            await _context.PuestosNegocios.AddAsync(ClienteDB);
            await _context.SaveChangesAsync();
        }
        public async Task Update(PuestosNegocio updatedClienteDB)
        {
            var ClienteDB = await _context.PuestosNegocios.FirstOrDefaultAsync(ClienteDB => ClienteDB.Id == updatedClienteDB.Id);

            if (ClienteDB != null)
            {
                _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ClienteDB = await _context.PuestosNegocios.FirstOrDefaultAsync(ClienteDB => ClienteDB.Id == id);
            if (ClienteDB != null)
            {
                _context.PuestosNegocios.Remove(ClienteDB);
                await _context.SaveChangesAsync();
            }
        }
    }
}