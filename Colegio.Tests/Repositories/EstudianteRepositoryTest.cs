using Colegio.Data;
using Colegio.Models;
using Colegio.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Tests.Repositories;

public class EstudianteRepositoryTest
{
    private async Task<DataContext> GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var databaseCotext = new DataContext(options);
        databaseCotext.Database.EnsureCreated();
        if (await databaseCotext.Estudiantes.CountAsync() <= 0)
        {
            databaseCotext.Estudiantes.AddRange(
                new Estudiante()
                {
                    Id = 1,
                    Curso = null,
                    NotasEstudiantes = null,
                    Usuario = new Usuario
                    {
                        Id = "123",
                        DireccionResidencia = "xxx",
                        GrupoSanguineo = "A+",
                        Nombre = "Pedro Pablo"
                    }
                },
                new Estudiante()
                {
                    Id = 2,
                    Curso = null,
                    NotasEstudiantes = null,
                    Usuario = new Usuario
                    {
                        Id = "124",
                        DireccionResidencia = "xxx",
                        GrupoSanguineo = "A+",
                        Nombre = "Pedro Pablo"
                    }
                }
            );
            await databaseCotext.SaveChangesAsync();
        }

        return databaseCotext;
    }
    
    [Fact]
    public async void EstudianteExists_ReturnTrue()
    {
        var numeroDocumento = 1;
        var dbContext = await GetDatabaseContext();
        var estudianteRepository = new EstudianteRepository(dbContext);

        var result = estudianteRepository.EstudianteExists(numeroDocumento);

        result.Should().BeTrue();
    }
    
    [Fact]
    public async void EstudianteExists_ReturnFalse()
    {
        var numeroDocumento = 3;
        var dbContext = await GetDatabaseContext();
        var estudianteRepository = new EstudianteRepository(dbContext);

        var result = estudianteRepository.EstudianteExists(numeroDocumento);

        result.Should().BeFalse();
    }
    
    [Fact]
    public async void GetById_ReturnEstudiante()
    {
        var numeroDocumento = 1;
        var dbContext = await GetDatabaseContext();
        var estudianteRepository = new EstudianteRepository(dbContext);

        var result = estudianteRepository.GetById(numeroDocumento);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(Estudiante));
    }
    
    
    
    [Fact]
    public async void GetById_ReturnNull()
    {
        var numeroDocumento = 3;
        var dbContext = await GetDatabaseContext();
        var estudianteRepository = new EstudianteRepository(dbContext);

        var result = estudianteRepository.GetById(numeroDocumento);

        result.Should().BeNull();
    }
    
    [Fact]
    public async void GetAllWithUsers_ReturnEstudiantes()
    {
        var dbContext = await GetDatabaseContext();
        var estudianteRepository = new EstudianteRepository(dbContext);

        var result = estudianteRepository.GetAllWithUsers();

        foreach (var es in result)
        {
            es.Usuario.Should().NotBeNull();
        }
    }
    
    [Fact]
    public async void GetByUsuarios_ReturnEstudiantes()
    {
        var listUsuarios = new List<String>();
        listUsuarios.Add("123");
        listUsuarios.Add("103");
        var dbContext = await GetDatabaseContext();
        var estudianteRepository = new EstudianteRepository(dbContext);

        var result = estudianteRepository.GetByUsuarios(listUsuarios);

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(List<Estudiante>));
    }
}