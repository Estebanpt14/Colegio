using Colegio.Models;

namespace Colegio.Repositories.IRepositories;

public interface IRolRepository : IRepository<Rol>
{
    Rol getByName(string name);
}