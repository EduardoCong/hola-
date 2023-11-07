using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features;

public class OrdenServices
{
    private readonly OrdenRepository _ordenRepository;
    private readonly SnackappDbContext _context;

    public OrdenServices(OrdenRepository ordenRepository, SnackappDbContext context)
    {
        this._ordenRepository = ordenRepository;
        this._context = context;
    }
    public async Task<List<Orden>> GetAllIncludingDetails()
    {
        // Utiliza Include para cargar los detalles de la orden relacionados
        return await _context.Orden
            .Include(o => o.DetallesOrden) // Asegúrate de que las relaciones estén definidas en tus modelos
            .ToListAsync();
    }

    public async Task<IEnumerable<Orden>> GetAll()
    {
        return await _ordenRepository.GetAll();
    }

    public async Task<Orden> GetById(int id)
    {
        return await _ordenRepository.GetById(id);
    }

    public async Task Add(Orden Orden)
    {
        await _ordenRepository.Add(Orden);
    }

    public async Task Update(Orden ordenToUpdate)
    {
        var orden = await GetById(ordenToUpdate.IdOrden);

        if (orden.IdOrden >= 0)
            await _ordenRepository.Update(ordenToUpdate);
    }
    public async Task<List<Orden>> GetOrdersByClienteId(int clienteId)
    {
        // Filtra las órdenes por el ID del cliente
        var ordenes = await _context.Orden
            .Where(o => o.IdCliente == clienteId)
            .ToListAsync();

        return ordenes;
    }

    public async Task Delete(int id)
    {
        var orden = await GetById(id);
        if (orden.IdOrden >= 0)
            await _ordenRepository.Delete(id);
    }
}
