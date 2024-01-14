using AutoMapper;
using Colegio.Dto;
using Colegio.Models;
using Colegio.Repositories.IRepositories;
using Colegio.Utilities;
using Colegio.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.Controllers;

[Route("estudiante")]
[ApiController]
public class EstudianteController : Controller
{
    private readonly IEstudianteRepository _estudianteRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

public EstudianteController(IEstudianteRepository estudianteRepository, IMapper mapper, 
        IUsuarioRepository usuarioRepository)
    {
        this._estudianteRepository = estudianteRepository;
        this._mapper = mapper;
        this._usuarioRepository = usuarioRepository;
    }

    [Authorize(Roles = DatabaseRoles.Estudiante)]
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Estudiante>))]
    [ProducesResponseType(500)]
    public IActionResult GetEstudiantes()
    {
        var estudiantesDto = _mapper.Map<List<EstudianteDto>>(
            _estudianteRepository.GetAllWithUsers());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(estudiantesDto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Estudiante))]
    [ProducesResponseType(400)]
    public IActionResult GetEstudiante(int id)
    {
        if (!_estudianteRepository.EstudianteExists(id))
            return NotFound();

        var estudiante = _mapper.Map<EstudianteDto>(_estudianteRepository.GetById(id));

        if (!ModelState.IsValid)
            return BadRequest();

        return Ok(estudiante);
    }

    [HttpPost("/create")]
    [ProducesResponseType(204, Type = typeof(string))]
    [ProducesResponseType(400)]
    public IActionResult CreateEstudiante([FromBody] RolDto rolDto)
    {
        if (!_usuarioRepository.UsuarioExists(rolDto.NumeroDocumento))
            return NotFound();
        
        var usuario = _usuarioRepository.Get(e => e.Id.Equals(rolDto.NumeroDocumento));

        var val = _estudianteRepository.GetByUsuario(usuario.Id);
        if (val == null)
        {
            return Conflict("El estudiante ya existe");
        }
        
        var estudiante = new Estudiante();
        estudiante.Usuario = usuario;
        
        _usuarioRepository.AddRolToUsuario(usuario, DatabaseRoles.Estudiante);
        _estudianteRepository.Add(estudiante);
        
        return Ok(estudiante);
    }

    [HttpPost("change_password")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult ChangePassword(UsuarioLoginDto loginDto, long id, string newPass)
    {
        if (!_estudianteRepository.EstudianteExists(id))
            return NotFound();

        var usuario = _usuarioRepository.GetUsuarioByUsernamePassword(
            loginDto.UserName, loginDto.Password);

        if (usuario == null)
            return NotFound();

        usuario.PasswordHash = Encryptor.Encrypt(newPass);
        _usuarioRepository.Update(usuario);

        if (!ModelState.IsValid)
            return BadRequest();

        return Ok();
    }
    
    [HttpPost("get_by_usuario")]
    [ProducesResponseType(200, Type = typeof(EstudianteDto))]
    [ProducesResponseType(404)]
    public IActionResult GetEstudianteByUsuario([FromBody] UsuarioLoginDto loginDto)
    {
        var usuario = _usuarioRepository.GetUsuarioByUsernamePassword(
            loginDto.UserName, loginDto.Password);

        if (usuario == null)
        {
            return NotFound("Usuario no encontrado");
        }

        var estudiante = _estudianteRepository.GetByUsuario(usuario.Id);

        if (estudiante == null)
        {
            return NotFound("Estudiante no encontrado");
        }

        var estudianteDto = _mapper.Map<EstudianteDto>(estudiante);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(estudianteDto);
    }
   
}