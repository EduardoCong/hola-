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
            var cliente = await _context.Clientes.ToListAsync();
            return cliente;
        }
        public async Task<Cliente> GetById(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.IdCliente == id);
            return cliente ?? new Cliente();
        }
        public async Task<Cliente> GetClienteByCorreoElectronico(string correo)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(cliente => cliente.CorreoElectronico == correo);
            return cliente ?? new Cliente();
        }
        public async Task Add(Cliente ClienteDB)
        {
            await _context.Clientes.AddAsync(ClienteDB);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Cliente updatedClienteDB)
        {
            var ClienteDB = await _context.Clientes.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdCliente == updatedClienteDB.IdCliente);

            if (ClienteDB != null)
            {
                _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {

            // Verificar si el cliente existe
            var existingCliente = await _context.Clientes.FindAsync(id);
            if (existingCliente == null)
            {
                // El cliente no existe, puedes manejar este caso según tus necesidades
                throw new Exception($"Cliente con ID {id} no encontrado.");
            }

            // Eliminar credenciales asociadas
            var existingCredenciales = await _context.CredencialesClientes
                .Where(c => c.IdCliente == id)
                .ToListAsync();

            _context.CredencialesClientes.RemoveRange(existingCredenciales);

            // Eliminar al cliente
            _context.Clientes.Remove(existingCliente);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }

    }
}
