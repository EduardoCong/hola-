using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;
namespace TostiElotes.Infrastructure.Repositories
{
    public class CredencialesClienteRepository
    {
        
        private readonly SnackappDbContext _context;
        public CredencialesClienteRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<IEnumerable<CredencialesCliente>> GetAll()
        {
            var cliente = await _context.CredencialesClientes.ToListAsync();
            return cliente;
        }
        public async Task<CredencialesCliente> GetById(int id)
        {
            var cliente = await _context.CredencialesClientes.FirstOrDefaultAsync(cliente => cliente.IdUsuario == id);
            return cliente ?? new CredencialesCliente();
        }
        public async Task<CredencialesCliente> GetClienteById(int id)
        {
            var cliente = await _context.CredencialesClientes.FirstOrDefaultAsync(cliente => cliente.IdCliente == id);
            return cliente ?? new CredencialesCliente();
        }
        public async Task Add(CredencialesCliente ClienteDB)
        {
            await _context.CredencialesClientes.AddAsync(ClienteDB);
            await _context.SaveChangesAsync();
        }
        public async Task Update(CredencialesCliente updatedClienteDB)
        {
            var ClienteDB = await _context.CredencialesClientes.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdUsuario == updatedClienteDB.IdUsuario);

            if (ClienteDB != null)
            {
                _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ClienteDB = await _context.CredencialesClientes.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdUsuario == id);
            if (ClienteDB != null)
            {
                _context.CredencialesClientes.Remove(ClienteDB);
                await _context.SaveChangesAsync();
            }
        }
    }
}