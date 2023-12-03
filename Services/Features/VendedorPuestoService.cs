using AutoMapper;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features
{
    public class VendedorPuestoService
    {

        private readonly VendedorPuestoRepository _clienteRepository;
        private readonly IMapper _mapper;

        public VendedorPuestoService(VendedorPuestoRepository clienteRepository, IMapper mapper)
        {
            this._clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VendedoresPuesto>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<VendedoresPuesto> GetById(int id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<VendedorPuestoDTO>> GetPuestosByIdVendedorAsync(int idVendedor)
        {
            var puestos = await _clienteRepository.GetPuestosByIdVendedorAsync(idVendedor);
            return _mapper.Map<List<VendedorPuestoDTO>>(puestos);
        }



        public async Task Add(VendedoresPuesto cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        public async Task Update(VendedoresPuesto clienteToUpdate)
        {
            var cliente = await GetById(clienteToUpdate.IdRelacion);

            if (cliente.IdRelacion >= 0)
            {
                await _clienteRepository.Update(clienteToUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var cliente = await GetById(id);
            if (cliente.IdRelacion >= 0)
            {
                await _clienteRepository.Delete(id);
            }
        }
    }
}