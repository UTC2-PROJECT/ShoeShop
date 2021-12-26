using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopSportShoes.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
