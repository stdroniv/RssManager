using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RssApi.DAL.Repository.Contracts;

namespace RssApi.DAL.Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T: class, new()
{
    private readonly AppDbContext _context;
    protected virtual DbSet<T> Entity { get; }

    public RepositoryBase(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        Entity = _context.Set<T>();
    }

    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ?
            _context.Set<T>().AsNoTracking() :
            _context.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges ?
            _context.Set<T>()
                .Where(expression)
                .AsNoTracking() :
            _context.Set<T>()
                .Where(expression);

    public void Add(T entity) => _context.Set<T>().Add(entity);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);
}