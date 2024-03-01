using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features
{
    public class ExtraService
    {

        private readonly ExtraRepository _ExtraRepository;

        public ExtraService(ExtraRepository extraRepository)
        {
            this._ExtraRepository = extraRepository;
        }

        public async Task<IEnumerable<Extra>> GetAll()
        {
            return await _ExtraRepository.GetAll();
        }

        public async Task<Extra> GetById(int id)
        {
            return await _ExtraRepository.GetById(id);
        }
        public async Task<Extra> GetClientByCorreoAndContrasena(string correo, string contrasena)
        {
            return await _ExtraRepository.GetClientByCorreoAndContrasena(correo, contrasena);
        }

        public async Task Add(Extra cliente)
        {
            await _ExtraRepository.Add(cliente);
        }

        // public async Task Update(Extra clienteToUpdate)
        // {
        //     // Obtener el cliente existente
        //     var existingCliente = await GetById(clienteToUpdate.IdExtra);

        //     if (existingCliente.IdExtra >= 0)
        //     {
        //         // Actualizar la tabla de clientes
        //         await _ExtraRepository.Update(clienteToUpdate);

        //         // Actualizar la tabla de credencialesclientes
        //         var credencialesCliente = await _credencialesVendedorRepository.GetVendedorById(clienteToUpdate.IdVendedor);

        //         if (credencialesCliente != null)
        //         {
        //             credencialesCliente.Usuario = clienteToUpdate.CorreoElectronico;
        //             credencialesCliente.Contraseña = clienteToUpdate.Contraseña;
        //             await _credencialesVendedorRepository.Update(credencialesCliente);
        //         }
        //     }
        // }
        // public async Task Delete(int id)
        // {
        //     var cliente = await GetById(id);
        //     if (cliente.IdVendedor >= 0)
        //     {
        //         await _clienteRepository.Delete(id);
        //     }
        // }
    }
}