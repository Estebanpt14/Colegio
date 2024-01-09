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
    private readonly IMapper _mapper;

    public UsuarioControllerTest()
    {
        _usuarioRepository = A.Fake<IUsuarioRepository>();
        _mapper = A.Fake<IMapper>();
    }

    [Fact]
    public void RegisterEstudiante_ReturnOk()
    {
        var usuario = A.Fake<Usuario>();
        var usuarioDto = A.Fake<UsuarioDto>();
        var usuarioExists = false;
        var usuarioExistsByUsername = false;
        var usuarioAdded = true;
        A.CallTo(() => _mapper.Map<Usuario>(usuarioDto)).Returns(usuario);
        A.CallTo(() => _usuarioRepository.UsuarioExists(usuarioDto.NumeroDocumento)).Returns(usuarioExists);
        A.CallTo(() => _usuarioRepository.UsuarioExistsByUsername(usuarioDto.UserName)).Returns(usuarioExistsByUsername);
        A.CallTo(() => _usuarioRepository.Add(usuario)).Returns(usuarioAdded);
        var controller = new UsuarioController(_mapper, _usuarioRepository);

        var result = controller.Register(usuarioDto);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkResult));
    }
    
    [Fact]
    public void RegisterEstudiante_ReturnConflict()
    {
        var usuario = A.Fake<Usuario>();
        var usuarioDto = A.Fake<UsuarioDto>();
        var usuarioExists = true;
        var usuarioExistsByUsername = false;
        var usuarioAdded = true;
        A.CallTo(() => _mapper.Map<Usuario>(usuarioDto)).Returns(usuario);
        A.CallTo(() => _usuarioRepository.UsuarioExists(usuarioDto.NumeroDocumento)).Returns(usuarioExists);
        A.CallTo(() => _usuarioRepository.UsuarioExistsByUsername(usuarioDto.UserName)).Returns(usuarioExistsByUsername);
        A.CallTo(() => _usuarioRepository.Add(usuario)).Returns(usuarioAdded);

        var controller = new UsuarioController(_mapper, _usuarioRepository);

        var result = controller.Register(usuarioDto);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(ConflictObjectResult));
    }
    
    [Fact]
    public void RegisterEstudiante_ReturnConflictUsername()
    {
        var usuario = A.Fake<Usuario>();
        var usuarioDto = A.Fake<UsuarioDto>();
        var usuarioExists = false;
        var usuarioExistsByUsername = true;
        var usuarioAdded = true;
        A.CallTo(() => _mapper.Map<Usuario>(usuarioDto)).Returns(usuario);
        A.CallTo(() => _usuarioRepository.UsuarioExists(usuarioDto.NumeroDocumento)).Returns(usuarioExists);
        A.CallTo(() => _usuarioRepository.UsuarioExistsByUsername(usuarioDto.UserName)).Returns(usuarioExistsByUsername);
        A.CallTo(() => _usuarioRepository.Add(usuario)).Returns(usuarioAdded);

        var controller = new UsuarioController(_mapper, _usuarioRepository);

        var result = controller.Register(usuarioDto);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(ConflictObjectResult));
    }
}