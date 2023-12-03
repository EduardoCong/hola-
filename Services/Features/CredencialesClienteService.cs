using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features
{
    public class CredencialesClienteService
    {
        
        private readonly CredencialesClienteRepository _clienteRepository;

        public CredencialesClienteService(CredencialesClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<CredencialesCliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<CredencialesCliente> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task Add(CredencialesCliente cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        public async Task Update(CredencialesCliente clienteToUpdate)
        {
            var cliente = await GetById(clienteToUpdate.IdUsuario);

            if (cliente.IdUsuario >= 0)
            {
                await _clienteRepository.Update(clienteToUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var cliente = await GetById(id);
            if (cliente.IdUsuario >= 0)
            {
                await _clienteRepository.Delete(id);
            }
        }
    }
}