using Colegio.Data;
using Colegio.Models;
using Colegio.Repositories.Interfaces;

namespace Colegio.Repositories;

public class EstudianteRepository : IEstudianteRepository
{
    private readonly DataContext _dataContext;
    
    public EstudianteRepository(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    public ICollection<Estudiante> GetEstudiantes()
    {
        return this._dataContext.Estudiantes.ToList();
    }
}