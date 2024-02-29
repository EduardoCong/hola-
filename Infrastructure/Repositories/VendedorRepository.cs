using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;

namespace TostiElotes.Infrastructure.Repositories
{
    public class VendedorRepository
    {

        private readonly SnackappDbContext _context;
        public VendedorRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<IEnumerable<Vendedor>> GetAll()
        {
            var cliente = await _context.Vendedores.ToListAsync();
            return cliente;
        }
        public async Task<Vendedor> GetById(int id)
        {
            var cliente = await _context.Vendedores.FirstOrDefaultAsync(cliente => cliente.IdVendedor == id);
            return cliente ?? new Vendedor();
        }
        public async Task<Vendedor> GetClientByCorreoAndContrasena(string correo, string contrasena)
        {
            var cliente = await _context.Vendedores.FirstOrDefaultAsync(cliente => cliente.CorreoElectronico == correo && cliente.Contraseña == contrasena);
            return cliente ?? new Vendedor();
        }
        public async Task Add(Vendedor ClienteDB)
        {
            await _context.Vendedores.AddAsync(ClienteDB);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Vendedor updatedClienteDB)
        {
            var ClienteDB = await _context.Vendedores.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdVendedor == updatedClienteDB.IdVendedor);

            if (ClienteDB != null)
            {
                _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Vendedor> GetVendedorByCorreoElectronico(string correo)
        {
            var cliente = await _context.Vendedores.FirstOrDefaultAsync(cliente => cliente.CorreoElectronico == correo);
            return cliente ?? new Vendedor();
        }
        public async Task Delete(int id)
        {

            // Verificar si el cliente existe
            var existingCliente = await _context.Vendedores.FindAsync(id);
            if (existingCliente == null)
            {
                // El cliente no existe, puedes manejar este caso según tus necesidades
                throw new Exception($"Vendedor con ID {id} no encontrado.");
            }

            // Eliminar credenciales asociadas
            var existingCredenciales = await _context.CredencialesVendedores
                .Where(c => c.IdVendedor == id)
                .ToListAsync();

            _context.CredencialesVendedores.RemoveRange(existingCredenciales);

            // Eliminar al cliente
            _context.Vendedores.Remove(existingCliente);

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();
        }
    }
}