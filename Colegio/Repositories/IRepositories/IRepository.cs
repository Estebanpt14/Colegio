using System.Linq.Expressions;

namespace Colegio.Repositories.IRepositories;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T Get(Expression<Func<T, bool>> filter);
    bool Add(T entity);
    bool Delete(T entity);
    bool DeleteRange(IEnumerable<T> entity);

    bool Update(T data);

}