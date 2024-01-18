using Colegio.Data;
using Colegio.Models;
using Colegio.Repositories.IRepositories;

namespace Colegio.Repositories;

public class RolRepository : Repository<Rol>, IRolRepository
{
    private readonly DataContext _dataContext;

    public RolRepository(DataContext dataContext) : base(dataContext)
    {
        this._dataContext = dataContext;
    }

    public Rol getByName(string name)
    {
        return _dataContext.Roles.FirstOrDefault(e => e.Name == name);
    }
}