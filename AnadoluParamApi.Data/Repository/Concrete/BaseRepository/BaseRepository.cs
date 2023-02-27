using AnadoluParamApi.Base.Model;
using AnadoluParamApi.Base.Types;
using AnadoluParamApi.Data.Context;
using AnadoluParamApi.Data.Repository.Abstract.BaseRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace AnadoluParamApi.Data.Repository.Concrete.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly AppDbContext Context;
        private DbSet<T> entities;
        public BaseRepository(AppDbContext dbContext)
        {
            this.Context = dbContext;
            this.entities = Context.Set<T>();
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression) //IsExist ?? 
        {
            return await entities.AnyAsync(expression);
        }

        public async Task DeleteAsync(T entity)
        {
            var column = entity.GetType().GetProperty("Status");
            if (column is not null)
            {
                entity.GetType().GetProperty("Status").SetValue(entity, Status.Deleted); //SoftDelete
            }
            else
            {
                entities.Remove(entity);//HardDelete
            }
        }

        public async Task<List<T>> GetByDefaults(Expression<Func<T, bool>> expression)
        {
            return await entities.Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = entities;
            if (include != null)
            {
                query = include(query);
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (orderBy != null)
            {
                return await orderBy(query).Select(selector).FirstOrDefaultAsync();
            }
            else
            {
                return await query.Select(selector).FirstOrDefaultAsync();
            }
        }

        public async Task<List<TResult>> GetFilteredFirstOrDefaults<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = entities;
            if (include != null)
            {
                query = include(query);
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (orderBy != null)
            {
                return await orderBy(query).Select(selector).ToListAsync();
            }
            else
            {
                return await query.Select(selector).ToListAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllListAsync() => await entities.Cast<T>().ToListAsync(); //GetAll List without any filtered

        public async Task InsertAsync(T model) => await entities.AddAsync(model); //Insert

        public void Update(T model) => entities.Update(model); //Update

        public async Task<T> GetByDefault(Expression<Func<T, bool>> expression)
        {
            var result = await entities.Where(expression).FirstOrDefaultAsync();
            return result;
        }
    }
}
