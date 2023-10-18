using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features
{
    public class DetalleOrdenServices
    {
        private readonly DetalleOrdenRepository _detalleOrdenRepository;

        public DetalleOrdenServices(DetalleOrdenRepository detalleOrdenRepository)
        {
            this._detalleOrdenRepository = detalleOrdenRepository;
        }

        public async Task<IEnumerable<DetalleOrden>> GetAll()
        {
            return await _detalleOrdenRepository.GetAll();
        }

        public async Task<DetalleOrden> GetById(int id)
        {
            return await _detalleOrdenRepository.GetById(id);
        }

        public async Task Add(DetalleOrden detalleOrden)
        {
            await _detalleOrdenRepository.Add(detalleOrden);
        }

        public async Task Update(DetalleOrden detalleOrdenToUpdate)
        {
            var detalleOrden = await GetById(detalleOrdenToUpdate.IdDetalle);

            if (detalleOrden.IdOrden >= 0)
            {
                await _detalleOrdenRepository.Update(detalleOrdenToUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var detalleOrden = await GetById(id);
            if (detalleOrden.IdOrden >= 0)
            {
                await _detalleOrdenRepository.Delete(id);
            }
        }
    }
}
