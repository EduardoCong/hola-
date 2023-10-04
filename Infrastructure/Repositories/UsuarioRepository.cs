using Microsoft.EntityFrameworkCore;
using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Data;

namespace TostiElotes.Infrastructure.Repositories
{
    public class usuarioRepository
    {
        private readonly ContexdataDB _context;
    public usuarioRepository(ContexdataDB context)
    {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        
    }
    public async Task<IEnumerable<Usuario>> GetAll()
    {
        var users = await _context.Usuarios.ToListAsync();
        return users;
    }
    public async Task<Usuario> GetById(int id)
    {
        var users = await _context.Usuarios.FirstOrDefaultAsync(users => users.id == id);
        return users ?? new Usuario();
    }
    public async Task Add(Usuario usuarioDB)
    {
        await _context.AddAsync(usuarioDB);
				await _context.SaveChangesAsync();
    }
    public async Task Update(Usuario updatedusuarioDB)
    {
        var usuarioDB = await _context.Usuarios.FirstOrDefaultAsync(usuarioDB => usuarioDB.id == updatedusuarioDB.id);

        if (usuarioDB != null)
        {
            _context.Entry(usuarioDB).CurrentValues.SetValues(updatedusuarioDB);
            await _context.SaveChangesAsync();
        }
    }
    public async Task Delete(int id)
    {
        var usuarioDB = await _context.Usuarios.FirstOrDefaultAsync(usuarioDB => usuarioDB.id == id);
        if (usuarioDB != null)
        {
            _context.Usuarios.Remove(usuarioDB);
            await _context.SaveChangesAsync();
        }
    }

    }
}