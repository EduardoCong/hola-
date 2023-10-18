using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;
namespace TostiElotes.Infrastructure.Repositories
{
    public class ClienteRepository
    {
        private readonly SnackappDbContext _context;
    public ClienteRepository(SnackappDbContext context)
    {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        
    }
    public async Task<IEnumerable<Cliente>> GetAll()
    {
        var users = await _context.Cliente.ToListAsync();
        return users;
    }
    public async Task<Cliente> GetById(int id)
    {
        var users = await _context.Cliente.FirstOrDefaultAsync(users => users.IdCliente == id);
        return users ?? new Cliente();
    }
    public async Task Add(Cliente ClienteDB)
    {
        await _context.Cliente.AddAsync(ClienteDB);
				await _context.SaveChangesAsync();
    }
    public async Task Update(Cliente updatedClienteDB)
    {
        var ClienteDB = await _context.Cliente.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdCliente == updatedClienteDB.IdCliente);

        if (ClienteDB != null)
        {
            _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
            await _context.SaveChangesAsync();
        }
    }
    public async Task Delete(int id)
    {
        var ClienteDB = await _context.Cliente.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdCliente == id);
        if (ClienteDB != null)
        {
            _context.Cliente.Remove(ClienteDB);
            await _context.SaveChangesAsync();
        }
    }

    }
}
