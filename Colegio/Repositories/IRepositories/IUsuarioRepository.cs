using Colegio.Models;

namespace Colegio.Repositories.IRepositories;

public interface IUsuarioRepository : IRepository<Usuario>
{
    bool UsuarioExists(string numeroDocumento);
    
    bool UsuarioExistsByUsername(string username);

    public void AddRolToUsuario(Usuario usuario, string nombreRol);

    public List<string> getIdsByRoleName(string roleName);
}