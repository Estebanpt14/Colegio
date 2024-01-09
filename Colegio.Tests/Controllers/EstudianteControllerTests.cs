using AutoMapper;
using Colegio.Controllers;
using Colegio.Dto;
using Colegio.Models;
using Colegio.Repositories.IRepositories;
using Colegio.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Controllers;

public class EstudianteControllerTests
{
    private readonly IEstudianteRepository _estudianteRepository = A.Fake<IEstudianteRepository>();
    private readonly IMapper _mapper = A.Fake<IMapper>();
    private readonly IUsuarioRepository _usuarioRepository = A.Fake<IUsuarioRepository>();

    [Fact]
    public void GetEstudiantes_ReturnOk()
    {
        var estudiantes = A.Fake<ICollection<Estudiante>>();
        var listEstudiantes = A.Fake<List<Estudiante>>();
        var listEstudiantesDto = A.Fake<List<EstudianteDto>>();
        A.CallTo(() => _estudianteRepository.GetAll()).Returns(listEstudiantes);
        A.CallTo(() => _mapper.Map<List<EstudianteDto>>(estudiantes)).Returns(listEstudiantesDto);
        var controller = new EstudianteController(_estudianteRepository, _mapper, _usuarioRepository);

        var result = controller.GetEstudiantes();

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }
    
    [Fact]
    public void GetEstudiante_ReturnOk()
    {
        var id = 1;
        var estudianteExists = true;
        var estudiante = A.Fake<Estudiante>();
        var estudianteDto = A.Fake<EstudianteDto>();
        A.CallTo(() => _estudianteRepository.EstudianteExists(id)).Returns(estudianteExists);
        A.CallTo(() => _estudianteRepository.GetById(id)).Returns(estudiante);
        A.CallTo(() => _mapper.Map<EstudianteDto>(estudiante)).Returns(estudianteDto);
        var controller = new EstudianteController(_estudianteRepository, _mapper, _usuarioRepository);

        var result = controller.GetEstudiante(id);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }
    
    [Fact]
    public void GetEstudiante_ReturnNotFound()
    {
        var id = 1;
        var estudianteExists = false;
        var estudiante = A.Fake<Estudiante>();
        var estudianteDto = A.Fake<EstudianteDto>();
        A.CallTo(() => _estudianteRepository.EstudianteExists(id)).Returns(estudianteExists);
        A.CallTo(() => _estudianteRepository.GetById(id)).Returns(estudiante);
        A.CallTo(() => _mapper.Map<EstudianteDto>(estudiante)).Returns(estudianteDto);
        var controller = new EstudianteController(_estudianteRepository, _mapper, _usuarioRepository);

        var result = controller.GetEstudiante(id);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundResult));
    }

    [Fact]
    public void CreateEstudiante_ReturnOk()
    {
        var rolDto = A.Fake<RolDto>();
        var usuarioExists = true;
        A.CallTo(() => _usuarioRepository.UsuarioExists(rolDto.NumeroDocumento)).Returns(usuarioExists);
        var controller = new EstudianteController(_estudianteRepository, _mapper, _usuarioRepository);

        var result = controller.CreateEstudiante(rolDto);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }
    
    [Fact]
    public void CreateEstudiante_ReturnNotFound()
    {
        var rolDto = A.Fake<RolDto>();
        var usuarioExists = false;
        A.CallTo(() => _usuarioRepository.UsuarioExists(rolDto.NumeroDocumento)).Returns(usuarioExists);
        var controller = new EstudianteController(_estudianteRepository, _mapper, _usuarioRepository);

        var result = controller.CreateEstudiante(rolDto);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundResult));
    }
}