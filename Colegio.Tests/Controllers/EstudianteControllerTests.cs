using AutoMapper;
using Colegio.Controllers;
using Colegio.Dto;
using Colegio.Models;
using Colegio.Repositories.IRepositories;
using Colegio.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Tests.Controllers;

public class EstudianteControllerTests
{
    private readonly IEstudianteRepository _estudianteRepository = A.Fake<IEstudianteRepository>();
    private readonly IMapper _mapper = A.Fake<IMapper>();
    private readonly IUsuarioRepository _usuarioRepository = A.Fake<IUsuarioRepository>();

    public EstudianteControllerTests()
    {

    }

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

    [Fact]
    public void ChangePassword_ReturnOk()
    {
        var estudianteExists = true;
        var updated = true;
        var id = 1L;
        var newPass = "xxx";
        var loginDto = A.Fake<UsuarioLoginDto>();
        var usuario = A.Fake<Usuario>();
        A.CallTo(() => _estudianteRepository.EstudianteExists(id)).Returns(estudianteExists);
        A.CallTo(() => _usuarioRepository.GetUsuarioByUsernamePassword(
            loginDto.UserName, loginDto.Password)).Returns(usuario);
        A.CallTo(() => _usuarioRepository.Update(usuario)).Returns(updated);
        var controller = new EstudianteController(_estudianteRepository, _mapper, _usuarioRepository);

        var result = controller.ChangePassword(loginDto, id, newPass);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkResult));
    }

    [Fact]
    public void ChangePassword_ReturnNotFound()
    {
        var estudianteExists = false;
        var updated = true;
        var id = 1L;
        var newPass = "xxx";
        var loginDto = A.Fake<UsuarioLoginDto>();
        var usuario = A.Fake<Usuario>();
        A.CallTo(() => _estudianteRepository.EstudianteExists(id)).Returns(estudianteExists);
        A.CallTo(() => _usuarioRepository.GetUsuarioByUsernamePassword(
            loginDto.UserName, loginDto.Password)).Returns(usuario);
        A.CallTo(() => _usuarioRepository.Update(usuario)).Returns(updated);
        var controller = new EstudianteController(_estudianteRepository, _mapper, _usuarioRepository);

        var result = controller.ChangePassword(loginDto, id, newPass);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundResult));
    }

    [Fact]
    public void GetEstudianteByUsuario_ReturnOk()
    {
        var loginDto = A.Fake<UsuarioLoginDto>();
        var usuario = A.Fake<Usuario>();
        var estudiante = A.Fake<Estudiante>();
        var estudianteDto = A.Fake<EstudianteDto>();
        A.CallTo(() => _usuarioRepository.GetUsuarioByUsernamePassword(
            loginDto.UserName, loginDto.Password)).Returns(usuario);
        A.CallTo(() => _estudianteRepository.GetByUsuario(usuario.Id)).Returns(estudiante);
        A.CallTo(() => _mapper.Map<EstudianteDto>(estudiante)).Returns(estudianteDto);
        var controller = new EstudianteController(_estudianteRepository, _mapper, _usuarioRepository);

        var result = controller.GetEstudianteByUsuario(loginDto);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }

    [Fact]
    public void GetEstudianteByUsuario_ReturnNotFoundUsuario()
    {
        var loginDto = A.Fake<UsuarioLoginDto>();
        var usuario = A.Fake<Usuario>();
        var estudiante = A.Fake<Estudiante>();
        var estudianteDto = A.Fake<EstudianteDto>();
        A.CallTo(() => _usuarioRepository.GetUsuarioByUsernamePassword(
            loginDto.UserName, loginDto.Password)).Returns(null);
        A.CallTo(() => _estudianteRepository.GetByUsuario(usuario.Id)).Returns(estudiante);
        A.CallTo(() => _mapper.Map<EstudianteDto>(estudiante)).Returns(estudianteDto);
        var controller = new EstudianteController(_estudianteRepository, _mapper, _usuarioRepository);

        var result = controller.GetEstudianteByUsuario(loginDto);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
    }

    [Fact]
    public void GetEstudianteByUsuario_ReturnNotFoundEstudiante()
    {
        var loginDto = A.Fake<UsuarioLoginDto>();
        var usuario = A.Fake<Usuario>();
        var estudiante = A.Fake<Estudiante>();
        var estudianteDto = A.Fake<EstudianteDto>();
        A.CallTo(() => _usuarioRepository.GetUsuarioByUsernamePassword(
            loginDto.UserName, loginDto.Password)).Returns(usuario);
        A.CallTo(() => _estudianteRepository.GetByUsuario(usuario.Id)).Returns(null);
        A.CallTo(() => _mapper.Map<EstudianteDto>(estudiante)).Returns(estudianteDto);
        var controller = new EstudianteController(_estudianteRepository, _mapper, _usuarioRepository);

        var result = controller.GetEstudianteByUsuario(loginDto);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
    }
}