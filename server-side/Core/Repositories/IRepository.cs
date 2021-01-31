using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task Toogle(long id, bool status);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task SoftDelete(TEntity entity);
#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        Task<PagedResult<TEntity>> Paginate<TEntity>(IQueryable<TEntity> query, int? page, int? pageSize = 15) where TEntity : class;
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
                              //Task<PagedByIdResult<TEntity>> PaginateByLastId<TEntity>(IQueryable<TEntity> query, long? lastId, int? pageSize = 15) where TEntity : class;
    }

    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int NextPage { get; set; }
        public int PreviousPage { get; set; }
    }

    public abstract class PagedByIdResultBase
    {
        public long LastId { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNextPage { get; set; }
    }

    public class PagedResult<TEntity> : PagedResultBase where TEntity : class
    {
        public IEnumerable<TEntity> Data { get; set; }

        public PagedResult()
        {
            Data = new List<TEntity>();
        }
    }

    public class PagedByIdResult<TEntity> : PagedByIdResultBase where TEntity : class
    {
        public IEnumerable<TEntity> Data { get; set; }

        public PagedByIdResult()
        {
            Data = new List<TEntity>();
        }
    }
}