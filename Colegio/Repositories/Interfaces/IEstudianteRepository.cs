using Colegio.Models;

namespace Colegio.Repositories.Interfaces;

public interface IEstudianteRepository
{
    ICollection<Estudiante> GetEstudiantes();
}