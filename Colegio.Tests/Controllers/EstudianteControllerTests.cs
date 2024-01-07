using AutoMapper;
using Colegio.Controllers;
using Colegio.Dto;
using Colegio.Models;
using Colegio.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Tests.Controllers;

public class EstudianteControllerTests
{
    private readonly IEstudianteRepository _estudianteRepository = A.Fake<IEstudianteRepository>();
    private readonly IMapper _mapper = A.Fake<IMapper>();

    [Fact]
    public void GetEstudiantes_ReturnOk()
    {
        var estudiantes = A.Fake<ICollection<Estudiante>>();
        var listEstudiantes = A.Fake<List<EstudianteDto>>();
        A.CallTo(() => _mapper.Map<List<EstudianteDto>>(estudiantes)).Returns(listEstudiantes);
        A.CallTo(() => _estudianteRepository.GetAll()).Returns(estudiantes);
        var controller = new EstudianteController(_estudianteRepository, _mapper);

        var result = controller.GetEstudiantes();

        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }
    
    [Fact]
    public void GetEstudiante_ReturnOk()
    {
        //Arrange
        var estudiante = A.Fake<Estudiante>();
        var estudianteDto = A.Fake<EstudianteDto>();
        var numeroDocumento = 1234;
        var estudianteExists = true;
        A.CallTo(() => _estudianteRepository.EstudianteExists(numeroDocumento)).Returns(estudianteExists);
        A.CallTo(() => _mapper.Map<EstudianteDto>(estudiante)).Returns(estudianteDto);
        A.CallTo(() => _estudianteRepository.GetByNumeroDocumento(numeroDocumento)).Returns(estudiante);
        var controller = new EstudianteController(_estudianteRepository, _mapper);
        
        //Act
        var result = controller.GetEstudiante(numeroDocumento);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkObjectResult));
    }
    
    [Fact]
    public void GetEstudiante_ReturnNotFound()
    {
        //Arrange
        var estudiante = A.Fake<Estudiante>();
        var estudianteDto = A.Fake<EstudianteDto>();
        var numeroDocumento = 1234;
        var estudianteExists = false;
        A.CallTo(() => _estudianteRepository.EstudianteExists(numeroDocumento)).Returns(estudianteExists);
        A.CallTo(() => _mapper.Map<EstudianteDto>(estudiante)).Returns(estudianteDto);
        A.CallTo(() => _estudianteRepository.GetByNumeroDocumento(numeroDocumento)).Returns(estudiante);
        var controller = new EstudianteController(_estudianteRepository, _mapper);
        
        //Act
        var result = controller.GetEstudiante(numeroDocumento);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(NotFoundResult));
    }

    [Fact]
    public void CreateEstudiante_ReturnOk()
    {
        var estudiante = A.Fake<Estudiante>(); 
        var estudianteDto = A.Fake<EstudianteDto>();
        var estudianteExists = false;
        var estudianteCreated = true;
        A.CallTo(() => _estudianteRepository.EstudianteExists(estudiante.NumeroDocumento))
            .Returns(estudianteExists);
        A.CallTo(() => _mapper.Map<Estudiante>(estudianteDto)).Returns(estudiante);
        A.CallTo(() => _estudianteRepository.Add(estudiante))
            .Returns(estudianteCreated);
        var controller = new EstudianteController(_estudianteRepository, _mapper);
        
        var result = controller.CreateEstudiante(estudianteDto);
        
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(OkResult));
    }
    
    [Fact]
    public void CreateEstudiante_ReturnConflict()
    {
        var estudiante = A.Fake<Estudiante>(); 
        var estudianteDto = A.Fake<EstudianteDto>();
        var estudianteExists = true;
        var estudianteCreated = true;
        A.CallTo(() => _estudianteRepository.EstudianteExists(estudiante.NumeroDocumento))
            .Returns(estudianteExists);
        A.CallTo(() => _estudianteRepository.Add(estudiante))
            .Returns(estudianteCreated);
        A.CallTo(() => _mapper.Map<Estudiante>(estudianteDto)).Returns(estudiante);
        var controller = new EstudianteController(_estudianteRepository, _mapper);
        
        var result = controller.CreateEstudiante(estudianteDto);
        
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(ConflictObjectResult));
    }
}