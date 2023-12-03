using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;

namespace TostiElotes.Infrastructure.Repositories
{
    public class VendedorPuestoRepository
    {

        private readonly SnackappDbContext _context;
        public VendedorPuestoRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<IEnumerable<VendedoresPuesto>> GetAll()
        {
            var cliente = await _context.VendedoresPuestos.ToListAsync();
            return cliente;
        }
        public async Task<VendedoresPuesto> GetByIdAsync(int id)
        {
            var vendedorPuesto = await _context.VendedoresPuestos
                .FirstOrDefaultAsync(cliente => cliente.IdRelacion == id);

            return vendedorPuesto ?? new VendedoresPuesto();
        }

       public async Task<IEnumerable<VendedoresPuesto>> GetPuestosByIdVendedorAsync(int idVendedor)
    {
        return await _context.VendedoresPuestos
            .Where(cliente => cliente.IdVendedor == idVendedor)
            .ToListAsync();
    }


        public async Task Add(VendedoresPuesto ClienteDB)
        {
            await _context.VendedoresPuestos.AddAsync(ClienteDB);
            await _context.SaveChangesAsync();
        }
        public async Task Update(VendedoresPuesto updatedClienteDB)
        {
            var ClienteDB = await _context.VendedoresPuestos.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdRelacion == updatedClienteDB.IdRelacion);

            if (ClienteDB != null)
            {
                _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ClienteDB = await _context.VendedoresPuestos.FirstOrDefaultAsync(ClienteDB => ClienteDB.IdRelacion == id);
            if (ClienteDB != null)
            {
                _context.VendedoresPuestos.Remove(ClienteDB);
                await _context.SaveChangesAsync();
            }
        }
    }
}