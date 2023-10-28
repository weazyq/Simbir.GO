using System.Linq.Expressions;

namespace EF.Repositories;
public class DbRepository : IDbRepository
{
    private readonly DataContext _context;

    public DbRepository(DataContext context)
    {
        _context = context;
    }

    public IQueryable<T> Get<T>() where T : class
    {
        return _context.Set<T>().AsQueryable();
    }

    public IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class
    {
        return _context.Set<T>().Where(selector).AsQueryable();
    }

    public async Task Add<T>(T newEntity) where T : class
    {
        await _context.Set<T>().AddAsync(newEntity);
    }

    public async Task AddRange<T>(IEnumerable<T> newEntities) where T : class
    {
        await _context.Set<T>().AddRangeAsync(newEntities);
    }

    public async Task Delete<T>(T entity) where T : class
    {
        await Task.Run(() => _context.Set<T>().Remove(entity));
    }

    public async Task DeleteRange<T>(IEnumerable<T> entities) where T : class
    {
        await Task.Run(() => _context.Set<T>().RemoveRange(entities));
    }

    public async Task Update<T>(T entity) where T : class
    {
        await Task.Run(() => _context.Set<T>().Update(entity));
    }

    public async Task UpdateRange<T>(IEnumerable<T> entities) where T : class
    {
        await Task.Run(() => _context.Set<T>().UpdateRange(entities));
    }
    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task<Int32> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public IQueryable<T> GetAll<T>() where T : class
    {
        return _context.Set<T>().AsQueryable();
    }
}
