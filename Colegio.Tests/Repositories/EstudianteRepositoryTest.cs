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
                    Correo = "prueba@gmail.com",
                    Curso = null,
                    DireccionResidencia = "Calle Larios #33-01",
                    Edad = 19,
                    FechaNacimiento = new DateOnly(2005, 1, 1),
                    GrupoSanguineo = "A+",
                    Nombre = "Maria del Pilar Sarmiento",
                    NotasEstudiantes = null,
                    NumeroDocumento = 1007819211,
                    Telefono = 3101232244
                },
                new Estudiante()
                {
                    Correo = "prueba1@gmail.com",
                    Curso = null,
                    DireccionResidencia = "Calle 33 #33-01",
                    Edad = 23,
                    FechaNacimiento = new DateOnly(2001, 1, 1),
                    GrupoSanguineo = "AB+",
                    Nombre = "Juan Pablo Cardenas Perez",
                    NotasEstudiantes = null,
                    NumeroDocumento = 10093177711,
                    Telefono = 3103432244
                },
                new Estudiante()
                {
                    Correo = "prueba2@gmail.com",
                    Curso = null,
                    DireccionResidencia = "Calle 21 #33-01",
                    Edad = 20,
                    FechaNacimiento = new DateOnly(2004, 1, 1),
                    GrupoSanguineo = "O+",
                    Nombre = "Maria Chavez Perez",
                    NotasEstudiantes = null,
                    NumeroDocumento = 1001237711,
                    Telefono = 3109818811
                }
            );
            await databaseCotext.SaveChangesAsync();
        }

        return databaseCotext;
    }

    [Fact]
    public async void GetEstudiantes_ReturnEstudiantes()
    {
        var nombre = "Maria del Pilar Sarmiento";
        var dbContext = await GetDatabaseContext();
        var estudianteRepository = new EstudianteRepository(dbContext);

        var result = estudianteRepository.Get(e => e.Nombre.Equals(nombre));

        result.Should().NotBeNull();
        result.Should().BeOfType<Estudiante>();
    }
    
    [Fact]
    public async void GetEstudianteByNumeroDocumento_ReturnEstudiante()
    {
        var numeroDocumento = 1007819211;
        var dbContext = await GetDatabaseContext();
        var estudianteRepository = new EstudianteRepository(dbContext);

        var result = estudianteRepository.GetByNumeroDocumento(numeroDocumento);

        result.Should().NotBeNull();
        result.Should().BeOfType<Estudiante>();
    }
    
    [Fact]
    public async void EstudianteExists_ReturnTrue()
    {
        var numeroDocumento = 1007819211;
        var dbContext = await GetDatabaseContext();
        var estudianteRepository = new EstudianteRepository(dbContext);

        var result = estudianteRepository.EstudianteExists(numeroDocumento);

        result.Should().BeTrue();
    }
    
    [Fact]
    public async void EstudianteExists_ReturnFalse()
    {
        var numeroDocumento = 1001928312;
        var dbContext = await GetDatabaseContext();
        var estudianteRepository = new EstudianteRepository(dbContext);

        var result = estudianteRepository.EstudianteExists(numeroDocumento);

        result.Should().BeFalse();
    }
}