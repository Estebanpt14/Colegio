using Colegio.Data;
using Colegio.Models;
using Colegio.Repositories.IRepositories;
using Colegio.Utilities;
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

    public Usuario GetUsuarioByUsernamePassword(string username, string password)
    {
        return _dataContext.Usuarios.FirstOrDefault(e => e.UserName == username
                                              && e.PasswordHash == Encryptor.Encrypt(password));
    }

    public void AddRolToUsuario(Usuario usuario, string nombreRol)
    {
        var result = _userManager.AddToRoleAsync(usuario, nombreRol);
        result.Wait();
    }

    public List<string> GetIdsByRoleName(string roleName)
    {
        var result = _userManager.GetUsersInRoleAsync(roleName);
        result.Wait();
        return result.Result.Select(e => e.Id).ToList();
    }

    public List<string> GetRoles(Usuario usuario)
    {
        var result = _userManager.GetRolesAsync(usuario);
        result.Wait();
        return result.Result.ToList();
    }
}