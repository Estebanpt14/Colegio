using Colegio.Data;
using Colegio.Models;
using Colegio.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Repositories;

public class EstudianteRepository : Repository<Estudiante>, IEstudianteRepository
{
    private readonly DataContext _dataContext;
    
    public EstudianteRepository(DataContext dataContext) : base(dataContext)
    {
        this._dataContext = dataContext;
    }

    public void Update(Estudiante estudiante)
    {
        _dataContext.Estudiantes.Update(estudiante);
        Save();
    }

    public void Save()
    {
        _dataContext.SaveChanges();
    }

    public IEnumerable<Estudiante> GetAllWithUsers()
    {
        return _dataContext.Estudiantes.Include(e => e.Usuario).ToList();
    }

    public bool EstudianteExists(long id)
    {
        return _dataContext.Estudiantes.Any(e => e.Id == id);
    }

    public Estudiante GetById(long id)
    {
        return _dataContext.Estudiantes.FirstOrDefault(e => e.Id == id);
    }

    public IEnumerable<Estudiante> GetByUsuarios(List<string> listUsuarios)
    {
        return _dataContext.Estudiantes
            .Where(e => e.Usuario != null && listUsuarios.Contains(e.Usuario.Id))
            .ToList();
    }
    
    public Estudiante GetByUsuario(string numeroDocumento)
    {
        return _dataContext.Estudiantes
            .FirstOrDefault(e => e.Usuario != null && e.UsuarioId == numeroDocumento);
    }
}