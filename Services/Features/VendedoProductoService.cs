using AutoMapper;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;
namespace TostiElotes.Services.Features
{
    public class VendedoProductoService
    {

        private readonly VendedorProductoRepository _clienteRepository;
                private readonly IMapper _mapper;

        public VendedoProductoService(VendedorProductoRepository clienteRepository, IMapper mapper)
        {
            this._clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VendedoresProducto>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<VendedoresProducto> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task<IEnumerable<VendedorProductoDTO>> GetPuestosByIdVendedorAsync(int idVendedor)
        {
            var puestos = await _clienteRepository.GetProductoByIdVendedorAsync(idVendedor);
            return _mapper.Map<List<VendedorProductoDTO>>(puestos);
        }

        public async Task Add(VendedoresProducto cliente)
        {
            await _clienteRepository.Add(cliente);
        }

        public async Task Update(VendedoresProducto clienteToUpdate)
        {
            var cliente = await GetById(clienteToUpdate.IdVendedorProducto);

            if (cliente.IdVendedorProducto >= 0)
            {
                await _clienteRepository.Update(clienteToUpdate);
            }
        }

        public async Task Delete(int id)
        {
            var cliente = await GetById(id);
            if (cliente.IdVendedorProducto >= 0)
            {
                await _clienteRepository.Delete(id);
            }
        }
    }
}