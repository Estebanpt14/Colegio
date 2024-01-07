using AutoMapper;
using Colegio.Controllers;
using Colegio.Dto;
using Colegio.Models;
using Colegio.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Controllers;

public class UsuarioControllerTest
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IEstudianteRepository _estudianteRepository;
    private readonly IMapper _mapper;

    public UsuarioControllerTest()
    {
        _usuarioRepository = A.Fake<IUsuarioRepository>();
        _estudianteRepository = A.Fake<IEstudianteRepository>();
        _mapper = A.Fake<IMapper>();
    }

    [Fact]
    public void RegisterEstudiante_ReturnOk()
    {
        var usuario = A.Fake<Usuario>();
        var usuarioDto = A.Fake<UsuarioDto>();
        var numeroDocumento = 1231;
        var usuarioExists = false;
        var estudianteExists = true;
        var usuarioAdded = true;
        A.CallTo(() => _mapper.Map<Usuario>(usuarioDto)).Returns(usuario);
        A.CallTo(() => _usuarioRepository.UsuarioExists(usuario.UserName)).Returns(usuarioExists);
        A.CallTo(() => _estudianteRepository.EstudianteExists(numeroDocumento)).Returns(estudianteExists);
        A.CallTo(() => _usuarioRepository.Add(usuario)).Returns(usuarioAdded);

        var controller = new UsuarioController(_mapper, _usuarioRepository, _estudianteRepository);

        var result = controller.RegisterEstudiante(usuarioDto, numeroDocumento);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkResult));
    }
    
    [Fact]
    public void RegisterEstudiante_ReturnConflict()
    {
        var usuario = A.Fake<Usuario>();
        var usuarioDto = A.Fake<UsuarioDto>();
        var numeroDocumento = 1231;
        var usuarioExists = true;
        var estudianteExists = true;
        var usuarioAdded = true;
        A.CallTo(() => _mapper.Map<Usuario>(usuarioDto)).Returns(usuario);
        A.CallTo(() => _usuarioRepository.UsuarioExists(usuario.UserName)).Returns(usuarioExists);
        A.CallTo(() => _estudianteRepository.EstudianteExists(numeroDocumento)).Returns(estudianteExists);
        A.CallTo(() => _usuarioRepository.Add(usuario)).Returns(usuarioAdded);

        var controller = new UsuarioController(_mapper, _usuarioRepository, _estudianteRepository);

        var result = controller.RegisterEstudiante(usuarioDto, numeroDocumento);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(ConflictObjectResult));
    }
    
    [Fact]
    public void RegisterEstudiante_ReturnNotFound()
    {
        var usuario = A.Fake<Usuario>();
        var usuarioDto = A.Fake<UsuarioDto>();
        var numeroDocumento = 1231;
        var usuarioExists = false;
        var estudianteExists = false;
        var usuarioAdded = true;
        A.CallTo(() => _mapper.Map<Usuario>(usuarioDto)).Returns(usuario);
        A.CallTo(() => _usuarioRepository.UsuarioExists(usuario.UserName)).Returns(usuarioExists);
        A.CallTo(() => _estudianteRepository.EstudianteExists(numeroDocumento)).Returns(estudianteExists);
        A.CallTo(() => _usuarioRepository.Add(usuario)).Returns(usuarioAdded);

        var controller = new UsuarioController(_mapper, _usuarioRepository, _estudianteRepository);

        var result = controller.RegisterEstudiante(usuarioDto, numeroDocumento);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
    }
}