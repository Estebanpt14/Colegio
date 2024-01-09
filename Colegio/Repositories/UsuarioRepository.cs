using Colegio.Data;
using Colegio.Models;
using Colegio.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace Colegio.Repositories;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    private readonly DataContext _dataContext;
    private readonly UserManager<Usuario> _userManager;
    
    public UsuarioRepository(DataContext dataContext, UserManager<Usuario> userManager) : base(dataContext)
    {
        this._dataContext = dataContext;
        this._userManager = userManager;
    }

    public bool UsuarioExists(string numeroDocumento)
    {
        return _dataContext.Usuarios.Any(e => e.Id.Equals(numeroDocumento));
    }

    public bool UsuarioExistsByUsername(string username)
    {
        return _dataContext.Usuarios.Any(e => e.UserName == username);
    }

    public void AddRolToUsuario(Usuario usuario, string nombreRol)
    {
        var result = _userManager.AddToRoleAsync(usuario,nombreRol);
        result.Wait();
    }

    public List<string> getIdsByRoleName(string roleName)
    {
        var result = _userManager.GetUsersInRoleAsync(roleName);
        result.Wait();
        return result.Result.Select(e => e.Id).ToList();
    }
}