using Colegio.Models;

namespace Colegio.Repositories.IRepositories;

public interface IUsuarioRepository : IRepository<Usuario>
{
    bool UsuarioExists(string username);
}