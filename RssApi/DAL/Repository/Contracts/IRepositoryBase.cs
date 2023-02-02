using System.Linq.Expressions;

namespace RssApi.DAL.Repository.Contracts;

public interface IRepositoryBase<T> where T: class, new()
{
    IQueryable<T> FindAll(bool trackChanges);

    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges);

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);
}