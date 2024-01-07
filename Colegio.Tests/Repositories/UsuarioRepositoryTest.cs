using Colegio.Data;
using Colegio.Models;
using Colegio.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Tests.Repositories;

public class UsuarioRepositoryTest
{
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
                    UserName = "akjsdh",
                    PasswordHash = "123123"
                },
                new Usuario()
                {
                    UserName = "akjsdh1",
                    PasswordHash = "1231231"
                }
            );
            await databaseCotext.SaveChangesAsync();
        }

        return databaseCotext;
    }
    
    [Fact]
    public async void EstudianteExists_ReturnTrue()
    {
        var username = "akjsdh";
        var dbContext = await GetDatabaseContext();
        var usuarioRepository = new UsuarioRepository(dbContext);

        var result = usuarioRepository.UsuarioExists(username);

        result.Should().BeTrue();
    }
    
    [Fact]
    public async void EstudianteExists_ReturnFalse()
    {
        var username = "1234";
        var dbContext = await GetDatabaseContext();
        var usuarioRepository = new UsuarioRepository(dbContext);

        var result = usuarioRepository.UsuarioExists(username);

        result.Should().BeFalse();
    }
}