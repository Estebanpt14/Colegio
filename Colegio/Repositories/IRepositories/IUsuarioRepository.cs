using Colegio.Models;

namespace Colegio.Repositories.IRepositories;

public interface IUsuarioRepository : IRepository<Usuario>
{
    bool UsuarioExists(string numeroDocumento);

    bool UsuarioExistsByUsername(string username);

    Usuario GetUsuarioByUsernamePassword(string username, string password);

    void AddRolToUsuario(Usuario usuario, string nombreRol);

    List<string> GetIdsByRoleName(string roleName);

    List<string> GetRoles(Usuario usuario);
}