using Colegio.Controllers;
using Colegio.Models;
using Colegio.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Controllers;

public class EstudianteControllerTests
{
    private readonly IEstudianteRepository _estudianteRepository;

    public EstudianteControllerTests()
    {
        _estudianteRepository = A.Fake<IEstudianteRepository>();
    }

    [Fact]
    public void GetEstudiantes_ReturnOk()
    {
        //Arrange
        var estudiantes = A.Fake<ICollection<Estudiante>>();
        var controller = new EstudianteController(this._estudianteRepository);
        
        //Act
        var result = controller.GetEstudiantes();

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }
}