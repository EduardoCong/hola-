using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features
{
    public class CredencialesVendedorService
    {
        
        private readonly CredencialesVendedorRepository _clienteRepository;

        public CredencialesVendedorService(CredencialesVendedorRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<CredencialesVendedore>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<CredencialesVendedore> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task Add(CredencialesVendedore cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        public async Task Update(CredencialesVendedore clienteToUpdate)
        {
            var cliente = await GetById(clienteToUpdate.IdCredencial);

            if (cliente.IdCredencial >= 0)
            {
                await _clienteRepository.Update(clienteToUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var cliente = await GetById(id);
            if (cliente.IdCredencial >= 0)
            {
                await _clienteRepository.Delete(id);
            }
        }
    }
}