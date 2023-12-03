using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;
namespace TostiElotes.Services.Features
{
    public class RepartidorService
    {

        private readonly RepartidorRepository _clienteRepository;
        private readonly CredencialesVendedorRepository _credencialesVendedorRepository;

        public RepartidorService(RepartidorRepository clienteRepository, CredencialesVendedorRepository credencialesVendedorRepository)
        {
            this._clienteRepository = clienteRepository;
            this._credencialesVendedorRepository = credencialesVendedorRepository;
        }

        public async Task<IEnumerable<Repartidor>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Repartidor> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task<Repartidor> GetClienteByCorreoElectronico(string correo)
        {
            return await _clienteRepository.GetClienteByCorreoElectronico(correo);
        }

        public async Task Add(Repartidor cliente)
        {
            await _clienteRepository.Add(cliente);
        }

         public async Task Update(Repartidor clienteToUpdate)
        {
            // Obtener el cliente existente
            var existingCliente = await GetById(clienteToUpdate.IdRepartidor);

            if (existingCliente.IdRepartidor >= 0)
            {
                // Actualizar la tabla de clientes
                await _clienteRepository.Update(clienteToUpdate);

                // Actualizar la tabla de credencialesclientes
                var credencialesCliente = await _credencialesVendedorRepository.GetVendedorById(clienteToUpdate.IdRepartidor);

                if (credencialesCliente != null)
                {
                    credencialesCliente.Usuario = clienteToUpdate.CorreoElectronico;
                    credencialesCliente.Contraseña = clienteToUpdate.Contraseña;
                    await _credencialesVendedorRepository.Update(credencialesCliente);
                }
            }
        }

        public async Task Delete(int id)
        {
            var cliente = await GetById(id);
            if (cliente.IdRepartidor >= 0)
            {
                await _clienteRepository.Delete(id);
            }
        }
    }
}