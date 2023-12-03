using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features
{
    public class NotificacionService
    {
        
        private readonly NotificacionesRepository _clienteRepository;

        public NotificacionService(NotificacionesRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Notificacione>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Notificacione> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task Add(Notificacione cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        public async Task Update(Notificacione clienteToUpdate)
        {
            var cliente = await GetById(clienteToUpdate.IdNotificacion);

            if (cliente.IdNotificacion >= 0)
            {
                await _clienteRepository.Update(clienteToUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var cliente = await GetById(id);
            if (cliente.IdNotificacion >= 0)
            {
                await _clienteRepository.Delete(id);
            }
        }
        
    }
}