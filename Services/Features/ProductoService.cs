using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features
{
    public class ProductoService
    {
        private readonly ProductoRepository _productoRepository;

        public ProductoService(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await _productoRepository.GetAll();
        }

        public async Task<Producto> GetById(int id)
        {
            return await _productoRepository.GetById(id);
        }
        public async Task<IEnumerable<Producto>> GetByIdPuesto(int id)
        {
            return await _productoRepository.GetByIdPuesto(id); 
        }
        public async Task Add(Producto producto)
        {
            await _productoRepository.Add(producto);
        }

        public async Task Update(Producto productoToUpdate)
        {
            var producto = await GetById(productoToUpdate.Id);

            if (producto != null)
            {
                await _productoRepository.Update(productoToUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var producto = await GetById(id);
            if (producto != null)
            {
                await _productoRepository.Delete(id);
            }
        }
    }
}
