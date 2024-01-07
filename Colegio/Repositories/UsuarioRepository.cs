using Colegio.Data;
using Colegio.Models;
using Colegio.Repositories.IRepositories;

namespace Colegio.Repositories;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    private readonly DataContext _dataContext;
    
    public UsuarioRepository(DataContext dataContext) : base(dataContext)
    {
        this._dataContext = dataContext;
    }

    public bool UsuarioExists(string username)
    {
        return _dataContext.Usuarios.Any(e => e.UserName == username);
    }
}