using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;

namespace TostiElotes.Infrastructure.Repositories
{
    public class ExtrasRepository
    {
        private readonly SnackappDbContext _context;
        public ExtrasRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<IEnumerable<Extra>> GetAll()
        {
            var cliente = await _context.Extra.ToListAsync();
            return cliente;
        }
        public async Task<Extra> GetById(int id)
        {
            var cliente = await _context.Extra.FirstOrDefaultAsync(cliente => cliente.id == id);
            return cliente ?? new Extra();
        }
        public async Task Add(Extra ClienteDB)
        {
            await _context.Extra.AddAsync(ClienteDB);
            await _context.SaveChangesAsync();
        }
        // public async Task Update(Extra updatedClienteDB)
        // {
        //     var ClienteDB = await _context.Extra.FirstOrDefaultAsync(ClienteDB => ClienteDB.id == updatedClienteDB.idproducto);

        //     if (ClienteDB != null)
        //     {
        //         _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
        //         await _context.SaveChangesAsync();
        //     }
        // }
        // public async Task Delete(int id)
        // {

        //     // Verificar si el cliente existe
        //     var existingCliente = await _context.Clientes.FindAsync(id);
        //     if (existingCliente == null)
        //     {
        //         // El cliente no existe, puedes manejar este caso según tus necesidades
        //         throw new Exception($"Cliente con ID {id} no encontrado.");
        //     }

        //     // Eliminar credenciales asociadas
        //     var existingCredenciales = await _context.CredencialesClientes
        //         .Where(c => c.IdCliente == id)
        //         .ToListAsync();

        //     _context.CredencialesClientes.RemoveRange(existingCredenciales);

        //     // Eliminar al cliente
        //     _context.Clientes.Remove(existingCliente);

        //     // Guardar cambios en la base de datos
        //     await _context.SaveChangesAsync();
        // }

    }
}
