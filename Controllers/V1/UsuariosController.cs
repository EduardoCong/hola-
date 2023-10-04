using Microsoft.AspNetCore.Mvc;

using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;
using AutoMapper;
using TostiElotes.Domain.Dtos;

namespace TostiElotes.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly UsuarioServices _usuarioService;
    private readonly IMapper _mapper;

    public UsuariosController(UsuarioServices usuarioServices, IMapper mapper)
    {
        this._usuarioService = usuarioServices ?? throw new ArgumentNullException(nameof (usuarioServices)); 
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _usuarioService.GetAll();
        var userDtos = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios); 
        
        return Ok(userDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByid(int id)
    {
        var usuarios = await _usuarioService.GetById(id);

        if (usuarios == null)
            return NotFound();

        var dto = _mapper.Map<UsuarioDTO>(usuarios); 

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(UsuarioCreateDTO usuarios)
    {
        var entity = _mapper.Map<Usuario>(usuarios);

        await _usuarioService.Add(entity);

        var dto = _mapper.Map<UsuarioDTO>(entity);
        return CreatedAtAction(nameof(GetByid), new { id = entity.id }, dto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Usuario usuario)
    {
        if(id !=usuario.id)
        return BadRequest();
        var existingUsuario = await _usuarioService.GetById(id);

        if(existingUsuario == null)
            return NotFound();
        _mapper.Map(usuario, existingUsuario);

        await _usuarioService.Update(existingUsuario);

        var updatedusuarioDB = await _usuarioService.GetById(id);
        var updateUsuarioDTO = _mapper.Map<UsuarioDTO>(updatedusuarioDB);

        return Ok(updateUsuarioDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _usuarioService.Delete(id);
        return NoContent();
    }
}