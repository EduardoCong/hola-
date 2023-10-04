using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features;

public class OrderServices
{
    private readonly OrderRepository _orderRepository;

    public OrderServices(OrderRepository orderRepository)
    {
        this._orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        return await _orderRepository.GetAll();
    }

    public async Task<Order> GetById(int id)
    {
        return await _orderRepository.GetById(id);
    }

    public async Task Add(Order Order)
    {
       await _orderRepository.Add(Order);
    }

    public async Task Update(Order orderToUpdate)
    {
        var order = GetById(orderToUpdate.Id);

        if (order.Id > 0)
           await _orderRepository.Update(orderToUpdate);
    }

    public async Task Delete(int id)
    {
        var order = GetById(id);
        if (order.Id > 0)
           await _orderRepository.Delete(id);
    }
}