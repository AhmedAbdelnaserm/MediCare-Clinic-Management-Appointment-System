using MediCare.Common.Enum;
using System.Linq.Expressions;

namespace MediCare.Core.IRepository.IRepository.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetPageAsync<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>>? filter,
           Expression<Func<T, TKey>> sortingExpression, SortDirectionEnum sortDir = SortDirectionEnum.Ascending,
           string includeProperties = "");
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetTakeCount<TKey>(int takeCount, Expression<Func<T, bool>>? filter = null, string includeProperties = "", Expression<Func<T, TKey>>? sortingExpression = null, SortDirectionEnum sortDir = SortDirectionEnum.Ascending);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? filter);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? filter, string includeProperties = "");
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>>? filter = null);
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>>? filter = null, string includeProperties = "");
        Task<bool> GetAnyAsync(Expression<Func<T, bool>>? filter = null);
        Task<int> GetCountAsync();
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);
        Task CreateListAsync(List<T> entityList);
        void Update(T entity);
        void UpdateList(List<T> entityList);
        void Delete(T entity);
        void DeleteList(List<T> entityList);
        //Task<int> Delete(Expression<Func<T, bool>> filter, string includeProperties = "");
    }
}
