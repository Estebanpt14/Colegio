using AutoMapper;
using Colegio.Dto;
using Colegio.Models;
using Colegio.Repositories.IRepositories;
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

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Estudiante>))]
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

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateEstudiante([FromBody] RolDto rolDto)
    {
        if (!_usuarioRepository.UsuarioExists(rolDto.NumeroDocumento))
            return NotFound();

        var usuario = _usuarioRepository.Get(e => e.Id.Equals(rolDto.NumeroDocumento));
        var estudiante = new Estudiante();
        estudiante.Usuario = usuario;
        
        _usuarioRepository.AddRolToUsuario(usuario, DatabaseRoles.Estudiante);
        _estudianteRepository.Add(estudiante);
        
        return Ok("Estudiante creado");
    }
    
}