using Colegio.Data;
using Colegio.Models;
using Colegio.Repositories.IRepositories;

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
    }

    public void Save()
    {
        _dataContext.SaveChanges();
    }

    public bool EstudianteExists(long numeroDocumento)
    {
        return _dataContext.Estudiantes.Any(e => e.NumeroDocumento == numeroDocumento);
    }

    public Estudiante GetByNumeroDocumento(long numeroDocumento)
    {
        return _dataContext.Estudiantes.FirstOrDefault(e => e.NumeroDocumento == numeroDocumento);
    }
}