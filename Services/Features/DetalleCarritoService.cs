using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features
{
    public class DetalleCarritoService
    {
        
        private readonly DetalleCarritoRepository _clienteRepository;

        public DetalleCarritoService(DetalleCarritoRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<DetalleCarrito>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<DetalleCarrito> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task Add(DetalleCarrito cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        public async Task Update(DetalleCarrito clienteToUpdate)
        {
            var cliente = await GetById(clienteToUpdate.IdDetalle);

            if (cliente.IdDetalle >= 0)
            {
                await _clienteRepository.Update(clienteToUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var cliente = await GetById(id);
            if (cliente.IdDetalle >= 0)
            {
                await _clienteRepository.Delete(id);
            }
        }
    }
}