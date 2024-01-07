using Colegio.Models;

namespace Colegio.Repositories.IRepositories;

public interface IEstudianteRepository : IRepository<Estudiante>
{
    void Update(Estudiante estudiante);
    void Save();

    bool EstudianteExists(long numeroDocumento);
    
    Estudiante GetByNumeroDocumento(long numeroDocumento);
}