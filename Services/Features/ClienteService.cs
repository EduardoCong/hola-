using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;
namespace TostiElotes.Services.Features
{
    public class ClienteService
    {


        private readonly ClienteRepository _clienteRepository;
        private readonly CredencialesClienteRepository _credencialesClienteRepository;

        public ClienteService(ClienteRepository clienteRepository, CredencialesClienteRepository credencialesClienteRepository)
        {
            this._clienteRepository = clienteRepository;
            this._credencialesClienteRepository = credencialesClienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }
        public async Task<IEnumerable<Orden>> GetOrdenesByIdCliente(int id)
        {
            return await _clienteRepository.GetOrdenesByIdCliente(id);
        }
        public async Task<Cliente> GetClienteByCorreoElectronico(string correo)
        {
            return await _clienteRepository.GetClienteByCorreoElectronico(correo);
        }

        public async Task Add(Cliente cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        public async Task Update(Cliente clienteToUpdate)
        {
            // Obtener el cliente existente
            var existingCliente = await GetById(clienteToUpdate.IdCliente);

            if (existingCliente.IdCliente >= 0)
            {
                // Actualizar la tabla de clientes
                await _clienteRepository.Update(clienteToUpdate);

                // Actualizar la tabla de credencialesclientes
                var credencialesCliente = await _credencialesClienteRepository.GetClienteById(clienteToUpdate.IdCliente);

                if (credencialesCliente != null)
                {
                    credencialesCliente.NomUsuario = clienteToUpdate.CorreoElectronico;
                    credencialesCliente.Contraseña = clienteToUpdate.Contrasena;
                    await _credencialesClienteRepository.Update(credencialesCliente);
                }
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
