using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;

namespace TostiElotes.Infrastructure.Repositories
{
    public class OrderRepository
    {
        private readonly ContexdataDB _context;
        public OrderRepository(ContexdataDB context)
        {
            this._context = context  ?? throw new ArgumentNullException(nameof(context));;
        }
        public async Task<IEnumerable<Order>> GetAll()
        {
            var orden = await _context.Order.ToListAsync();
            return orden;
        }
        public  async Task<Order> GetById(int id)
        {
            var orders = await _context.Order.FirstOrDefaultAsync(order => order.Id == id);
            return orders ?? new Order();
        }
        public async Task Add(Order orders)
        {
            await _context.AddAsync(orders);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Order updatedOrder)
        {
            var orden = await _context.Order.FirstOrDefaultAsync(orden => orden.Id == updatedOrder.Id);
            if (orden != null){
                _context.Entry(orden).CurrentValues.SetValues(updatedOrder);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var order = await _context.Order.FirstOrDefaultAsync(order => order.Id == id);
           if(order != null){
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
           }
        }
    }
}