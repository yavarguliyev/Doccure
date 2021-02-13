using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region
        protected readonly DataContext Context;

        public Repository(DataContext context)
        {
            this.Context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity> GetByIdAsync(long id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task SoftDelete(TEntity entity)
        {
            PropertyInfo propertyInfo = entity.GetType().GetProperty("DeletedAt");
            DateTime? deleteDate = DateTime.Now;
            propertyInfo.SetValue(entity, deleteDate, null);

            await Context.SaveChangesAsync();
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task Toogle(long id, bool status)
        {
            TEntity entity = await Context.Set<TEntity>().FindAsync(id);

            PropertyInfo propertyInfo = entity.GetType().GetProperty("Status");
            propertyInfo.SetValue(entity, Convert.ChangeType(status, propertyInfo.PropertyType), null);

            await Context.SaveChangesAsync();
        }

#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        public async Task<PagedResult<TEntity>> Paginate<TEntity>(IQueryable<TEntity> query, int? page, int? pageSize = 15) where TEntity : class
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
        {
            var result = new PagedResult<TEntity>();
            result.CurrentPage = page.HasValue && page.Value > 1 ? page.Value : 1;
            result.PageSize = pageSize ?? 15;
            result.TotalCount = query.Count();

            var pageCount = (double)result.TotalCount / result.PageSize;
            result.PagesCount = (int)Math.Ceiling(pageCount);

            result.NextPage = result.PagesCount > result.CurrentPage ? result.CurrentPage + 1 : 0;
            result.PreviousPage = result.CurrentPage > 1 ? result.CurrentPage - 1 : 0;

            var skip = (result.CurrentPage - 1) * result.PageSize;
            result.Data = await query.Skip(skip).Take(result.PageSize).ToListAsync();

            return result;
        }
        #endregion
    }
}