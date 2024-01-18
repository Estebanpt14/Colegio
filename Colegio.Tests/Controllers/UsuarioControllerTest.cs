using AutoMapper;
using Colegio.Controllers;
using Colegio.Dto;
using Colegio.Models;
using Colegio.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Tests.Controllers;

public class UsuarioControllerTest
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public UsuarioControllerTest()
    {
        _usuarioRepository = A.Fake<IUsuarioRepository>();
        _mapper = A.Fake<IMapper>();
        _configuration = A.Fake<IConfiguration>();
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
        var controller = new UsuarioController(_mapper, _usuarioRepository, _configuration);

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

        var controller = new UsuarioController(_mapper, _usuarioRepository, _configuration);

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

        var controller = new UsuarioController(_mapper, _usuarioRepository, _configuration);

        var result = controller.Register(usuarioDto);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(ConflictObjectResult));
    }

    [Fact]
    public void Login_ReturnOk()
    {
        var usuarioDto = A.Fake<UsuarioLoginDto>();
        var usuario = A.Fake<Usuario>();
        var roles = A.Fake<List<String>>();
        var issuer = new string("https://joydipkanjilal.com/");
        var audience = new string("https://joydipkanjilal.com/");
        var key = new string("Rj8L0I+XX7THm+6fTNZzq4+JvoXQHbF90bNZR9FLdZ23fyZJ3PmJp8N9p6qVvL8Vdu2ekYP5U6FcrLdfgIeMgOv30a+zQ7DeONf7XEq5+Gv6Em5ZdMg8PwShyEgyb8G");
        var usuarioExists = true;
        A.CallTo(() => _usuarioRepository.UsuarioExistsByUsername(usuarioDto.UserName))
            .Returns(usuarioExists);
        A.CallTo(() => _usuarioRepository.GetUsuarioByUsernamePassword
            (usuarioDto.UserName, usuarioDto.Password)).Returns(usuario);
        A.CallTo(() => _usuarioRepository.GetRoles(usuario)).Returns(roles);
        A.CallTo(() => _configuration["Jwt:Key"]).Returns(key);
        A.CallTo(() => _configuration["Jwt:Issuer"]).Returns(issuer);
        A.CallTo(() => _configuration["Jwt:Audience"]).Returns(audience);
        var controller = new UsuarioController(_mapper, _usuarioRepository, _configuration);

        var result = controller.Login(usuarioDto);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }

    [Fact]
    public void Login_ReturnNotFound()
    {
        var usuarioDto = A.Fake<UsuarioLoginDto>();
        var usuario = A.Fake<Usuario>();
        var roles = A.Fake<List<String>>();
        var issuer = new string("https://joydipkanjilal.com/");
        var audience = new string("https://joydipkanjilal.com/");
        var key = new string("Rj8L0I+XX7THm+6fTNZzq4+JvoXQHbF90bNZR9FLdZ23fyZJ3PmJp8N9p6qVvL8Vdu2ekYP5U6FcrLdfgIeMgOv30a+zQ7DeONf7XEq5+Gv6Em5ZdMg8PwShyEgyb8G");
        var usuarioExists = false;
        A.CallTo(() => _usuarioRepository.UsuarioExistsByUsername(usuarioDto.UserName))
            .Returns(usuarioExists);
        A.CallTo(() => _usuarioRepository.GetUsuarioByUsernamePassword
            (usuarioDto.UserName, usuarioDto.Password)).Returns(usuario);
        A.CallTo(() => _usuarioRepository.GetRoles(usuario)).Returns(roles);
        A.CallTo(() => _configuration["Jwt:Key"]).Returns(key);
        A.CallTo(() => _configuration["Jwt:Issuer"]).Returns(issuer);
        A.CallTo(() => _configuration["Jwt:Audience"]).Returns(audience);
        var controller = new UsuarioController(_mapper, _usuarioRepository, _configuration);

        var result = controller.Login(usuarioDto);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundObjectResult));
    }
}