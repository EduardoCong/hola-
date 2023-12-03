using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;
namespace TostiElotes.Services.Features
{
    public class SeguimientoEstadoService
    {

        private readonly SeguimientoEstadoRepository _clienteRepository;
        private readonly SnackappDbContext _context;


        public SeguimientoEstadoService(SeguimientoEstadoRepository clienteRepository, SnackappDbContext snackappDbContext)
        {
            this._clienteRepository = clienteRepository;
            _context = snackappDbContext;

        }

        public async Task<IEnumerable<SeguimientoEstado>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<SeguimientoEstado> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task Add(SeguimientoEstado cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        public async Task Update(SeguimientoEstado clienteToUpdate)
        {
            var cliente = await GetById(clienteToUpdate.IdSeguimiento);

            if (cliente.IdSeguimiento >= 0)
            {
                await _clienteRepository.Update(clienteToUpdate);
            }
        }
        public async Task ActualizarEstadoCarrito(int? idCarrito, string nuevoEstado)
        {
            // Llamada al procedimiento almacenado usando tu DbContext o el mecanismo que estés utilizando para interactuar con la base de datos.
            // Por ejemplo, si estás utilizando Entity Framework:

            await _context.Database.ExecuteSqlRawAsync("ActualizarEstadoCarrito @p0, @p1", idCarrito!, nuevoEstado);
        }
        public async Task Delete(int id)
        {
            var cliente = await GetById(id);
            if (cliente.IdSeguimiento >= 0)
            {
                await _clienteRepository.Delete(id);
            }
        }
    }
}