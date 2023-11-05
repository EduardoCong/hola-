using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore; // Asegúrate de agregar la referencia a Entity Framework

namespace TostiElotes.Services.Features
{
    public class DetalleOrdenServices
    {
        private readonly DetalleOrdenRepository _detalleOrdenRepository;
        private readonly SnackappDbContext _dbContext; // Debes agregar tu contexto de base de datos aquí

        public DetalleOrdenServices(DetalleOrdenRepository detalleOrdenRepository, SnackappDbContext dbContext)
        {
            this._detalleOrdenRepository = detalleOrdenRepository;
            this._dbContext = dbContext; // Asigna el contexto de base de datos
        }

        public async Task<IEnumerable<DetalleOrden>> GetAll()
        {
            return await _detalleOrdenRepository.GetAll();
        }

        public async Task<IEnumerable<DetalleOrden>> GetByOrderId(int orderId)
        {
            var detallesOrden = await _dbContext.DetallesOrden
                .Where(d => d.IdOrden == orderId)
                .ToListAsync();
            return detallesOrden;
        }


        public async Task Add(DetalleOrden detalleOrden)
        {
            await _detalleOrdenRepository.Add(detalleOrden);
        }

        public async Task DeleteByOrderId(int orderId)
        {
            // Aquí obtén los detalles de la orden que tienen el orderId proporcionado y elimínalos
            var detallesOrden = await _dbContext.DetallesOrden
                .Where(d => d.IdOrden == orderId)
                .ToListAsync();

            _dbContext.DetallesOrden.RemoveRange(detallesOrden);
            await _dbContext.SaveChangesAsync();
        }
    }
}
