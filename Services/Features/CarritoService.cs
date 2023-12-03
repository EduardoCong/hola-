using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features
{
    public class CarritoService
    {
        
        private readonly CarritoComprasRepository _clienteRepository;

        public CarritoService(CarritoComprasRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<CarritoDeCompra>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<CarritoDeCompra> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task Add(CarritoDeCompra cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        public async Task Update(CarritoDeCompra clienteToUpdate)
        {
            var cliente = await GetById(clienteToUpdate.IdCarrito);

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