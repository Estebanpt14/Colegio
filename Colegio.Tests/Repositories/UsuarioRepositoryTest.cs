using Colegio.Data;
using Colegio.Models;
using Colegio.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Tests.Repositories;

public class UsuarioRepositoryTest
{
    private readonly UserManager<Usuario> _userManager;

    public UsuarioRepositoryTest()
    {
        this._userManager = A.Fake<UserManager<Usuario>>();
    }
    private async Task<DataContext> GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var databaseCotext = new DataContext(options);
        databaseCotext.Database.EnsureCreated();
        if (await databaseCotext.Usuarios.CountAsync() <= 0)
        {
            databaseCotext.Usuarios.AddRange(
                new Usuario()
                {
                    Id = "123",
                    UserName = "akjsdh",
                    PasswordHash = "123123",
                    DireccionResidencia = "x",
                    GrupoSanguineo = "A+",
                    Nombre = "Pedro Dominguez"
                },
                new Usuario()
                {
                    Id = "1234",
                    UserName = "akjsdh1",
                    PasswordHash = "1231231",
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
    public async void UsuarioExists_ReturnTrue()
    {
        var numeroDocumento = "123";
        var dbContext = await GetDatabaseContext();
        var usuarioRepository = new UsuarioRepository(dbContext, _userManager);

        var result = usuarioRepository.UsuarioExists(numeroDocumento);

        result.Should().BeTrue();
    }
    
    [Fact]
    public async void UsuarioExists_ReturnFalse()
    {
        var numeroDocumento = "120";
        var dbContext = await GetDatabaseContext();
        var usuarioRepository = new UsuarioRepository(dbContext, _userManager);

        var result = usuarioRepository.UsuarioExists(numeroDocumento);

        result.Should().BeFalse();
    }
    
    [Fact]
    public async void UsuarioExistsByUsername_ReturnTrue()
    {
        var username = "akjsdh";
        var dbContext = await GetDatabaseContext();
        var usuarioRepository = new UsuarioRepository(dbContext, _userManager);

        var result = usuarioRepository.UsuarioExistsByUsername(username);

        result.Should().BeTrue();
    }
    
    [Fact]
    public async void UsuarioExistsByUsername_ReturnFalse()
    {
        var username = "1234";
        var dbContext = await GetDatabaseContext();
        var usuarioRepository = new UsuarioRepository(dbContext, _userManager);

        var result = usuarioRepository.UsuarioExistsByUsername(username);

        result.Should().BeFalse();
    }
}