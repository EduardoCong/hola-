using TostiElotes.Domain.Entities;
using TostiElotes.Infrastructure.Repositories;
using TostiElotes.Services.Features;
using Microsoft.Data.SqlClient;


namespace TostiElotes.Services.Features;

public class UsuarioServices
{
    private readonly usuarioRepository _usuarioRepository;

    public UsuarioServices(usuarioRepository userRepository)
    {
        this._usuarioRepository = userRepository;
    }

    public async Task<IEnumerable<Usuario>> GetAll()
    {
        return await _usuarioRepository.GetAll();
    }

    public async Task<Usuario> GetById(int id)
    {
        return await _usuarioRepository.GetById(id);
    }

    public async Task Add(Usuario usuario)
    {
        await _usuarioRepository.Add(usuario);
    }

    public async Task Update(Usuario usuarioToUpdate)
    {
        var usuario = GetById(usuarioToUpdate.id);

        if (usuario.Id > 0)
            await _usuarioRepository.Update(usuarioToUpdate);
    }

    public async Task Delete(int id)
    {
        var usuario = GetById(id);

        if (usuario.Id > 0)
            await _usuarioRepository.Delete(id);
    }
}

