using System.Linq.Expressions;

namespace EF.Repositories;
public interface IDbRepository
{
    IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class;
    IQueryable<T> Get<T>() where T : class;
    IQueryable<T> GetAll<T>() where T : class;

    Task Add<T>(T newEntity) where T : class;
    Task AddRange<T>(IEnumerable<T> newEntities) where T : class;

    Task Delete<T>(T entity) where T : class;
    Task DeleteRange<T>(IEnumerable<T> entities) where T : class;

    Task Update<T>(T entity) where T : class;
    Task UpdateRange<T>(IEnumerable<T> entities) where T : class;

    void SaveChanges();
    Task<Int32> SaveChangesAsync();
}
