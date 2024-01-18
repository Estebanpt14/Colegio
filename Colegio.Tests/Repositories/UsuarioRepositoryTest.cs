using Colegio.Data;
using Colegio.Models;
using Colegio.Repositories;
using Colegio.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Tests.Repositories;

public class UsuarioRepositoryTest
{
    private readonly UserManager<Usuario> _userManager;
    private DataContext DataBaseContext;

    public UsuarioRepositoryTest()
    {
        this._userManager = A.Fake<UserManager<Usuario>>();
        var aux = GetDatabaseContext();
        aux.Wait();
        DataBaseContext = aux.Result;
    }
    private async Task<DataContext> GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var databaseCotext = new DataContext(options);
        databaseCotext.Database.EnsureCreated();
        if (await databaseCotext.Usuarios.CountAsync() <= 1)
        {
            databaseCotext.Usuarios.AddRange(
                new Usuario()
                {
                    Id = "123",
                    UserName = "akjsdh",
                    PasswordHash = Encryptor.Encrypt("123123"),
                    DireccionResidencia = "x",
                    GrupoSanguineo = "A+",
                    Nombre = "Pedro Dominguez"
                },
                new Usuario()
                {
                    Id = "1234",
                    UserName = "akjsdh1",
                    PasswordHash = Encryptor.Encrypt("1231231"),
                    DireccionResidencia = "x",
                    GrupoSanguineo = "A+",
                    Nombre = "Pablo Dominguez"
                }
            );
            await databaseCotext.SaveChangesAsync();
        }

        return databaseCotext;
    }

    [Fact]
    public void UsuarioExists_ReturnTrue()
    {
        var numeroDocumento = "123";
        var usuarioRepository = new UsuarioRepository(DataBaseContext, _userManager);

        var result = usuarioRepository.UsuarioExists(numeroDocumento);

        result.Should().BeTrue();
    }

    [Fact]
    public void UsuarioExists_ReturnFalse()
    {
        var numeroDocumento = "120";
        var usuarioRepository = new UsuarioRepository(DataBaseContext, _userManager);

        var result = usuarioRepository.UsuarioExists(numeroDocumento);

        result.Should().BeFalse();
    }

    [Fact]
    public void UsuarioExistsByUsername_ReturnTrue()
    {
        var username = "akjsdh";
        var usuarioRepository = new UsuarioRepository(DataBaseContext, _userManager);

        var result = usuarioRepository.UsuarioExistsByUsername(username);

        result.Should().BeTrue();
    }

    [Fact]
    public void UsuarioExistsByUsername_ReturnFalse()
    {
        var username = "1234";
        var usuarioRepository = new UsuarioRepository(DataBaseContext, _userManager);

        var result = usuarioRepository.UsuarioExistsByUsername(username);

        result.Should().BeFalse();
    }

    [Fact]
    public void GetUsuarioByUsernamePassword_ReturnUsuario()
    {
        var username = "akjsdh";
        var passwordHash = "123123";
        var usuarioRepository = new UsuarioRepository(DataBaseContext, _userManager);

        var result = usuarioRepository.GetUsuarioByUsernamePassword(username, passwordHash);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(Usuario));
    }

    [Fact]
    public void GetUsuarioByUsernamePassword_ReturnNull()
    {
        var username = "akjsdh1";
        var passwordHash = "12233123";
        var usuarioRepository = new UsuarioRepository(DataBaseContext, _userManager);

        var result = usuarioRepository.GetUsuarioByUsernamePassword(username, passwordHash);

        result.Should().BeNull();
    }
}