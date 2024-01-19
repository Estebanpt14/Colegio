using Colegio.Models;

namespace Colegio.Repositories.IRepositories;

public interface IEstudianteRepository : IRepository<Estudiante>
{
    IEnumerable<Estudiante> GetAllWithUsers();

    bool EstudianteExists(long id);

    Estudiante GetById(long id);

    IEnumerable<Estudiante> GetByUsuarios(List<string> listUsuarios);

    Estudiante GetByUsuario(string numeroDocumento);
    
    bool ExistsByUsuario(string numeroDocumento);
}