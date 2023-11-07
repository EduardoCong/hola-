using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TostiElotes.Services.Features
{
    public class EstadoEntregaServices
    {
        private readonly EstadoEntregaRepository _estadoEntregaRepository;
        private readonly SnackappDbContext _dbContext;

        public EstadoEntregaServices(EstadoEntregaRepository estadoEntregaRepository, SnackappDbContext dbContext)
        {
            this._estadoEntregaRepository = estadoEntregaRepository;
            this._dbContext = dbContext;
        }
        public async Task Update(EstadoEntrega estadoEntrega)
        {
            await _estadoEntregaRepository.Update(estadoEntrega);
        }

        public async Task<IEnumerable<EstadoEntrega>> GetAll()
        {
            return await _estadoEntregaRepository.GetAll();
        }


        public async Task Add(EstadoEntrega estadoEntrega)
        {
            await _estadoEntregaRepository.AddEstadoEntrega(estadoEntrega);
        }
        public async Task<EstadoEntrega> GetById(int id)
        {
            return await _estadoEntregaRepository.GetById(id);
        }



        public async Task DeleteByOrderId(int orderId)
        {
            // Aquí obtén los estados de entrega que tienen el orderId proporcionado y elimínalos
            var estadosEntrega = await _dbContext.EstadoEntrega
                .Where(e => e.IdOrden == orderId)
                .ToListAsync();

            _dbContext.EstadoEntrega.RemoveRange(estadosEntrega);
            await _dbContext.SaveChangesAsync();
        }
    }
}
