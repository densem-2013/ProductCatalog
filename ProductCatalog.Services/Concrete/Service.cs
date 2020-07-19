using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProductCatalog.DAL;
using ProductCatalog.DAL.Entities;
using ProductCatalog.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductCatalog.Services.Concrete
{
    public class Service<T> : IService<T> where T : class, IBaseEntity
    {
        protected readonly DataContext _db;
        protected readonly DbSet<T> DbSet;

        public Service(DataContext dataContext)
        {
            _db = dataContext;
            DbSet = dataContext.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            await DbSet.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<int> Delete(params object[] ids)
        {
            T item = await DbSet.FindAsync(ids);
            if (item != null)
                DbSet.Remove(item);

            return await _db.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(params object[] ids)
        {
            return await DbSet.FindAsync(ids);
        }

        public async Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> selectExpression, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = DbSet;

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.Select(selectExpression).ToListAsync();
        }

        public async Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<T, TResult>> selectExpression,
            Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = DbSet;

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.Select(selectExpression).SingleOrDefaultAsync();
        }

        public async Task<T> Update(T entity)
        {
            DbSet.Update(entity);

            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
