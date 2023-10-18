using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features
{
    public class ClienteServices
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteServices(ClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task Add(Cliente cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        public async Task Update(Cliente clienteToUpdate)
        {
            var cliente = await GetById(clienteToUpdate.IdCliente);

            if (cliente.IdCliente >= 0)
            {
                await _clienteRepository.Update(clienteToUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var cliente = await GetById(id);
            if (cliente.IdCliente >= 0)
            {
                await _clienteRepository.Delete(id);
            }
        }
    }
}
