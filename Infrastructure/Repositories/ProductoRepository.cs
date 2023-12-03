using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;

namespace TostiElotes.Infrastructure.Repositories
{
    public class ProductoRepository
    {

        private readonly SnackappDbContext _context;
        public ProductoRepository(SnackappDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<IEnumerable<Producto>> GetAll()
        {
            var cliente = await _context.Productos.ToListAsync();
            return cliente;
        }
        public async Task<Producto> GetById(int id)
        {
            var cliente = await _context.Productos.FirstOrDefaultAsync(cliente => cliente.Id == id);
            return cliente ?? new Producto();
        }
        public async Task Add(Producto producto)
        {
           
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Producto updatedClienteDB)
        {
            var ClienteDB = await _context.Productos.FirstOrDefaultAsync(ClienteDB => ClienteDB.Id == updatedClienteDB.Id);

            if (ClienteDB != null)
            {
                _context.Entry(ClienteDB).CurrentValues.SetValues(updatedClienteDB);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var ClienteDB = await _context.Productos.FirstOrDefaultAsync(ClienteDB => ClienteDB.Id == id);
            if (ClienteDB != null)
            {
                _context.Productos.Remove(ClienteDB);
                await _context.SaveChangesAsync();
            }
        }
         private static async Task<byte[]> LeerImagenComoBytesAsync(string rutaImagen)
        {
            try
            {
                using (FileStream fileStream = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        await fileStream.CopyToAsync(memoryStream);
                        return memoryStream.ToArray();
                    }
                }
            }
            catch (IOException ex)
            {
                // Manejar la excepción (por ejemplo, registrarla o lanzarla nuevamente)
                throw new Exception($"Error al leer la imagen: {ex.Message}", ex);
            }
        }
    }
}