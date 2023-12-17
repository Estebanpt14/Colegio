using Colegio.Models;
using Colegio.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstudianteController : Controller
{
    private readonly IEstudianteRepository _estudianteRepository;
    
    public EstudianteController(IEstudianteRepository estudianteRepository)
    {
        this._estudianteRepository = estudianteRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Estudiante>))]
    public IActionResult GetEstudiantes()
    {
        var estudiantes = _estudianteRepository.GetEstudiantes();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(estudiantes);
    }
}