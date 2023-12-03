using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;

namespace TostiElotes.Infrastructure.Repositories
{
    public class CredencialesVendedorRepository
    {

        private readonly SnackappDbContext _context;
        public CredencialesVendedorRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<IEnumerable<CredencialesVendedore>> GetAll()
        {
            var cliente = await _context.CredencialesVendedores.ToListAsync();
            return cliente;
        }
        public async Task<CredencialesVendedore> GetById(int id)
        {
            var cliente = await _context.CredencialesVendedores.FirstOrDefaultAsync(cliente => cliente.IdCredencial == id);
            return cliente ?? new CredencialesVendedore();
        }
        public async Task<CredencialesVendedore> GetVendedorById(int id)
        {
            var cliente = await _context.CredencialesVendedores.FirstOrDefaultAsync(cliente => cliente.IdVendedor == id);
            return cliente ?? new CredencialesVendedore();
        }
        public async Task Add(CredencialesVendedore ClienteDB)
        {
            await _context.CredencialesVendedores.AddAsync(ClienteDB);
            await _context.SaveChangesAsync();
        }
        public async Task Update(CredencialesVendedore updatedClienteDB)
        {
            var ClienteDB = await _context.CredencialesVendedores.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdCredencial == updatedClienteDB.IdCredencial);

            if (ClienteDB != null)
            {
                _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ClienteDB = await _context.CredencialesVendedores.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdCredencial == id);
            if (ClienteDB != null)
            {
                _context.CredencialesVendedores.Remove(ClienteDB);
                await _context.SaveChangesAsync();
            }
        }
    }
}