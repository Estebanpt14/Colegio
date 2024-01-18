using System.Linq.Expressions;
using Colegio.Data;
using Colegio.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DataContext _dataContext;
    internal DbSet<T> dbSet;

    public Repository(DataContext dataContext)
    {
        this._dataContext = dataContext;
        this.dbSet = _dataContext.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        IQueryable<T> query = dbSet;
        return query.ToList();
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(filter);
        return query.FirstOrDefault();
    }

    public bool Add(T entity)
    {
        this.dbSet.Add(entity);
        return Save();
    }

    public bool Delete(T entity)
    {
        this.dbSet.Remove(entity);
        return Save();
    }

    public bool DeleteRange(IEnumerable<T> entity)
    {
        this.dbSet.RemoveRange(entity);
        return Save();
    }

    public bool Update(T data)
    {
        this.dbSet.Update(data);
        return Save();
    }

    public bool Save()
    {
        return _dataContext.SaveChanges() > 0;
    }
}