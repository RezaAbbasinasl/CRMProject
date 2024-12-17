using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryPattern;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity 
{
    private readonly CRMDbContext _dbContext;

    public BaseRepository(CRMDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> CreateDataAsync(T data)
    {
        await _dbContext.Set<T>().AddAsync(data);
        await CommitAsync();
        return data;
    }

    public async Task<T?> GetAsync(Guid id, bool AsNoTracking = true, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        var query = _dbContext.Set<T>().AsQueryable();
        query = AsNoTracking ? query.AsNoTracking() : query;
        query = include == null ? query : include(query);

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, bool AsNoTracking = true, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
    {
        var query = _dbContext.Set<T>().AsQueryable();
        query = AsNoTracking ? query.AsNoTracking() : query;
        query = include == null ? query : include(query);

        return await query.Where(predicate).ToListAsync();
    }

    public async Task<T> UpdateDataAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await CommitAsync();
        return entity;
    }
    public async Task<bool> DeleteDataAsync(Guid id)
    {
        var data = await GetAsync(id);
        if (data != null)
        {
            _dbContext.Set<T>().Remove(data);
            await CommitAsync();
            return true;
        }
        return false;
    }

    public async Task<int> CommitAsync() => await _dbContext.SaveChangesAsync();

  

}
