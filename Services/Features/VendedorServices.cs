using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features
{
    public class VendedorServices
    {
        private readonly VendedorRepository _vendedorRepository;

        public VendedorServices(VendedorRepository vendedorRepository)
        {
            this._vendedorRepository = vendedorRepository;
        }

        public async Task<IEnumerable<Vendedor>> GetAll()
        {
            return await _vendedorRepository.GetAll();
        }

        public async Task<Vendedor> GetById(int id)
        {
            return await _vendedorRepository.GetById(id);
        }

        public async Task Add(Vendedor vendedor)
        {
            await _vendedorRepository.Add(vendedor);
        }

        public async Task Update(Vendedor vendedorToUpdate)
        {
            var vendedor = await GetById(vendedorToUpdate.IdVendedor);

            if (vendedor.IdVendedor >= 0)
            {
                await _vendedorRepository.Update(vendedorToUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var vendedor = await GetById(id);
            if (vendedor.IdVendedor >= 0)
            {
                await _vendedorRepository.Delete(id);
            }
        }
    }
}
