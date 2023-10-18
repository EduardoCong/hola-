using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;

namespace TostiElotes.Services.Features;

public class OrdenServices
{
    private readonly OrdenRepository _ordenRepository;

    public OrdenServices(OrdenRepository ordenRepository)
    {
        this._ordenRepository = ordenRepository;
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

    public async Task Delete(int id)
    {
        var orden = await GetById(id);
        if (orden.IdOrden >= 0)
            await _ordenRepository.Delete(id);
    }
}
