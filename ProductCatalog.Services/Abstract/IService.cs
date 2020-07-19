using Microsoft.EntityFrameworkCore.Query;
using ProductCatalog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductCatalog.Services.Abstract
{
    public interface IService<T> where T : IBaseEntity
    {
        Task<T> GetByIdAsync(params object[] ids);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<int> Delete(params object[] ids);
        Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> selectExpression,
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, TResult>> selectExpression,
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    }
}
