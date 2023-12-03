using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;
namespace TostiElotes.Infrastructure.Repositories
{
    public class CarritoComprasRepository
    {
        
        private readonly SnackappDbContext _context;
    public CarritoComprasRepository(SnackappDbContext context)
    {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        
    }
    public async Task<IEnumerable<CarritoDeCompra>> GetAll()
    {
        var carrito = await _context.CarritoDeCompras.ToListAsync();
        return carrito;
    }
    public async Task<CarritoDeCompra> GetById(int id)
    {
        var carrito = await _context.CarritoDeCompras.FirstOrDefaultAsync(carrito => carrito.IdCarrito == id);
        return carrito ?? new CarritoDeCompra();
    }
    public async Task Add(CarritoDeCompra CarritoDeCompraDB)
    {
        await _context.CarritoDeCompras.AddAsync(CarritoDeCompraDB);
				await _context.SaveChangesAsync();
    }
    public async Task Update(CarritoDeCompra updatedCarritoDeCompraDB)
    {
        var CarritoDeCompraDB = await _context.CarritoDeCompras.FirstOrDefaultAsync(CarritoDeCompraDB => CarritoDeCompraDB.IdCarrito == updatedCarritoDeCompraDB.IdCarrito);

        if (CarritoDeCompraDB != null)
        {
            _context.Entry(CarritoDeCompraDB).CurrentValues.SetValues(updatedCarritoDeCompraDB);
            await _context.SaveChangesAsync();
        }
    }
    public async Task Delete(int id)
    {
        var CarritoDeCompraDB = await _context.CarritoDeCompras.FirstOrDefaultAsync(CarritoDeCompraDB => CarritoDeCompraDB.IdCarrito == id);
        if (CarritoDeCompraDB != null)
        {
            _context.CarritoDeCompras.Remove(CarritoDeCompraDB);
            await _context.SaveChangesAsync();
        }
    }

    }
}
