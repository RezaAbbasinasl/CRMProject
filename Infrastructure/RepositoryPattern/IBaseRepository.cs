using Microsoft.EntityFrameworkCore.Query;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryPattern
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> CreateDataAsync(T data);

        Task<T?> GetAsync(Guid id, bool AsNoTracking = true,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate, bool AsNoTracking = true,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<T> UpdateDataAsync(T entity);

        Task<bool> DeleteDataAsync(Guid id);
    }
}
