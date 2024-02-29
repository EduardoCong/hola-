using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features
{
    public class VendedorService
    {

        private readonly VendedorRepository _clienteRepository;
        private readonly CredencialesVendedorRepository _credencialesVendedorRepository;

        public VendedorService(VendedorRepository clienteRepository, CredencialesVendedorRepository credencialesVendedorRepository)
        {
            this._clienteRepository = clienteRepository;
            this._credencialesVendedorRepository = credencialesVendedorRepository;
        }

        public async Task<IEnumerable<Vendedor>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Vendedor> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }
        public async Task<Vendedor> GetClientByCorreoAndContrasena(string correo, string contrasena)
        {
            return await _clienteRepository.GetClientByCorreoAndContrasena(correo, contrasena);
        }

        public async Task Add(Vendedor cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        public async Task Update(Vendedor clienteToUpdate)
        {
            // Obtener el cliente existente
            var existingCliente = await GetById(clienteToUpdate.IdVendedor);

            if (existingCliente.IdVendedor >= 0)
            {
                // Actualizar la tabla de clientes
                await _clienteRepository.Update(clienteToUpdate);

                // Actualizar la tabla de credencialesclientes
                var credencialesCliente = await _credencialesVendedorRepository.GetVendedorById(clienteToUpdate.IdVendedor);

                if (credencialesCliente != null)
                {
                    credencialesCliente.Usuario = clienteToUpdate.CorreoElectronico;
                    credencialesCliente.Contraseña = clienteToUpdate.Contraseña;
                    await _credencialesVendedorRepository.Update(credencialesCliente);
                }
            }
        }
        public async Task<Vendedor> GetVendedorByCorreoElectronico(string correo)
        {
            return await _clienteRepository.GetVendedorByCorreoElectronico(correo);
        }
        public async Task Delete(int id)
        {
            var cliente = await GetById(id);
            if (cliente.IdVendedor >= 0)
            {
                await _clienteRepository.Delete(id);
            }
        }
    }
}