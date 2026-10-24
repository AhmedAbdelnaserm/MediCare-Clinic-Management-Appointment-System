using MediCare.Common.Enum;
using MediCare.Core.IRepository.IRepository.Base;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace MediCare.Infrastructure.Repository.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Vars
        public ApplicationDbContext AppDbContext { get; }
        #endregion

        #region INI
        internal BaseRepository(ApplicationDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }
        #endregion

        #region Get Page
        public async Task<List<T>> GetPageAsync<TKey>(int skipCount, int takeCount, Expression<Func<T, bool>> filter,
            Expression<Func<T, TKey>> sortingExpression, Common.Enum.SortDirectionEnum sortDir = Common.Enum.SortDirectionEnum.Ascending,
            string includeProperties = "")
        {
            IQueryable<T> query = AppDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            skipCount = skipCount * takeCount;
            switch (sortDir)
            {
                case Common.Enum.SortDirectionEnum.Ascending:
                    query = query.OrderBy<T, TKey>(sortingExpression).Skip(skipCount).Take(takeCount);
                    break;
                case Common.Enum.SortDirectionEnum.Descending:
                    query = query.OrderByDescending<T, TKey>(sortingExpression).Skip(skipCount).Take(takeCount);
                    break;
                default:
                    break;
            }
            return await query.ToListAsync();

        }
        #endregion

        #region Get Take Count
        public async Task<List<T>> GetTakeCount<TKey>(int takeCount, Expression<Func<T, bool>> filter = null,
            string includeProperties = "", Expression<Func<T, TKey>> sortingExpression = null,
            SortDirectionEnum sortDir = SortDirectionEnum.Ascending)
        {
            IQueryable<T> query = AppDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            if (sortingExpression != null)
            {
                switch (sortDir)
                {
                    case Common.Enum.SortDirectionEnum.Ascending:
                        query = query.OrderBy<T, TKey>(sortingExpression);
                        break;
                    case Common.Enum.SortDirectionEnum.Descending:
                        query = query.OrderByDescending<T, TKey>(sortingExpression);
                        break;
                    default:
                        break;
                }
            }
            return await query.Take(takeCount).ToListAsync();

        }

        #endregion

        #region GetAll
        public async Task<List<T>> GetAllAsync()
        {
            return await AppDbContext.Set<T>().ToListAsync();
        }
        #endregion

        #region First Or Default
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = AppDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, string includeProperties = "")
        {
            IQueryable<T> query = AppDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.FirstOrDefaultAsync();
        }
        #endregion

        #region Get Where
        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = AppDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = AppDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync();
        }
        public async Task<List<T>> GetWhereAsync<TKey>(Expression<Func<T, bool>> filter,
            Expression<Func<T, TKey>> sortingExpression,
            SortDirectionEnum sortDir = SortDirectionEnum.Ascending, string includeProperties = "")
        {
            IQueryable<T> query = AppDbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            switch (sortDir)
            {
                case Common.Enum.SortDirectionEnum.Ascending:
                    query = query.OrderBy<T, TKey>(sortingExpression);
                    break;
                case Common.Enum.SortDirectionEnum.Descending:
                    query = query.OrderByDescending<T, TKey>(sortingExpression);
                    break;
                default:
                    break;
            }

            return await query.ToListAsync();
        }


        #endregion

        #region Get Any
        public async Task<bool> GetAnyAsync(Expression<Func<T, bool>> filter = null)
        {
            return await AppDbContext.Set<T>().AnyAsync(filter);
        }
        #endregion

        #region Get Count
        public async Task<int> GetCountAsync()
        {
            return await AppDbContext.Set<T>().CountAsync();
        }
        public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter)
        {
            return await AppDbContext.Set<T>().Where(filter).CountAsync();
        }
        #endregion

        #region Create 
        public async Task CreateAsync(T entity)
        {
           await AppDbContext.Set<T>().AddAsync(entity);
        }
        public async Task CreateListAsync(List<T> entityList)
        {
           await AppDbContext.Set<T>().AddRangeAsync(entityList);
        }
        #endregion

        #region Update
        public void Update(T entity)
        {
            AppDbContext.Set<T>().Update(entity);
        }
        public void UpdateList(List<T> entityList)
        {
            AppDbContext.Set<T>().UpdateRange(entityList);
        }
        #endregion

        #region Delete
        public void Delete(T entity)
        {
            AppDbContext.Set<T>().Remove(entity);
        }
        public void DeleteList(List<T> entityList)
        {
            AppDbContext.Set<T>().RemoveRange(entityList);
        }
        //public async Task<int> Delete(Expression<Func<T, bool>> filter, string includeProperties = "")
        //{
        //    IQueryable<T> query = AppDbContext.Value.Set<T>().Where(filter);
        //    query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        //        .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        //    return await query.DeleteFromQueryAsync();
        //}
        public abstract Expression<Func<T, object>> ColumnsMap(string sortingExpression);
        #endregion

        #region Transaction
        public IDbContextTransaction BeginTransaction()
        {
            return AppDbContext.Database.BeginTransaction();
        }
        #endregion

        #region ExecuteSqlRawAsync
        public void ExecuteSqlRawAsync(string command)
        {
            AppDbContext.Database.ExecuteSqlRawAsync(command);
        }
        #endregion

    }
}
