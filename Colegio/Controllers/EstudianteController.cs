using AutoMapper;
using Colegio.Dto;
using Colegio.Models;
using Colegio.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.Controllers;

[Authorize]
[Route("estudiante")]
[ApiController]
public class EstudianteController : Controller
{
    private readonly IEstudianteRepository _estudianteRepository;
    private readonly IMapper _mapper;
    
    public EstudianteController(IEstudianteRepository estudianteRepository, IMapper mapper)
    {
        this._estudianteRepository = estudianteRepository;
        this._mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Estudiante>))]
    public IActionResult GetEstudiantes()
    {
        var estudiantes = _mapper.Map<List<EstudianteDto>>(_estudianteRepository.GetAll());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(estudiantes);
    }

    [HttpGet("{numeroDocumento}")]
    [ProducesResponseType(200, Type = typeof(Estudiante))]
    [ProducesResponseType(400)]
    public IActionResult GetEstudiante(int numeroDocumento)
    {
        if (!_estudianteRepository.EstudianteExists(numeroDocumento))
            return NotFound();

        var estudiante = _mapper.Map<EstudianteDto>(_estudianteRepository.GetByNumeroDocumento(numeroDocumento));

        if (!ModelState.IsValid)
            return BadRequest();

        return Ok(estudiante);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateEstudiante([FromBody] EstudianteDto estudianteDto)
    {
        if (_estudianteRepository.EstudianteExists(estudianteDto.NumeroDocumento))
            return Conflict("The Object Already Exists");
        
        if (!ModelState.IsValid)
            return BadRequest();

        if (_estudianteRepository.Add(_mapper.Map<Estudiante>(estudianteDto)))
            return Ok();

        ModelState.AddModelError("", "Something Wrong Happened");
        return StatusCode(500, ModelState);
    }
    
}