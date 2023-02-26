using AnadoluParamApi.Base.Model;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace AnadoluParamApi.Data.Repository.Abstract.BaseRepository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        //Add
        Task InsertAsync(T model);
        //Update
        void Update(T model);
        //Delete
        Task DeleteAsync(T model);
        //List
        Task<IEnumerable<T>> GetAllListAsync();
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetByDefaults(Expression<Func<T, bool>> expression);

        Task<bool> Any(Expression<Func<T, bool>> expression);
        Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector,
                                                         Expression<Func<T, bool>> expression,
                                                         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<List<TResult>> GetFilteredFirstOrDefaults<TResult>(Expression<Func<T, TResult>> selector,
                                                         Expression<Func<T, bool>> expression,
                                                         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
