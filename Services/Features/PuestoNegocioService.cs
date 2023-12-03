using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;
namespace TostiElotes.Services.Features
{
    public class PuestoNegocioService
    {
        
        private readonly PuestonegocioRepository _clienteRepository;

        public PuestoNegocioService(PuestonegocioRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<PuestosNegocio>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<PuestosNegocio> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task Add(PuestosNegocio cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        public async Task Update(PuestosNegocio clienteToUpdate)
        {
            var cliente = await GetById(clienteToUpdate.Id);

            if (cliente.Id >= 0)
            {
                await _clienteRepository.Update(clienteToUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var cliente = await GetById(id);
            if (cliente.Id >= 0)
            {
                await _clienteRepository.Delete(id);
            }
        }
    }
}