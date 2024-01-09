using Colegio.Models;

namespace Colegio.Repositories.IRepositories;

public interface IEstudianteRepository : IRepository<Estudiante>
{
    void Update(Estudiante estudiante);
    void Save();

    IEnumerable<Estudiante> GetAllWithUsers();

    bool EstudianteExists(long id);
    
    Estudiante GetById(long id);

    public IEnumerable<Estudiante> GetByUsuarios(List<string> listUsuarios);
}