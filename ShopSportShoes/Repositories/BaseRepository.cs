using Microsoft.EntityFrameworkCore;
using ShopSportShoes.Data;
using ShopSportShoes.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopSportShoes.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        readonly IDbContextFactory<ShoeShopDbContext> _contextFactory;
        private DbSet<T> _dbset;
        public BaseRepository(IDbContextFactory<ShoeShopDbContext> context)
        {
            _contextFactory = context ??
                throw new ArgumentNullException(nameof(context));
            _dbset = _contextFactory.CreateDbContext().Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            var context = _contextFactory.CreateDbContext();
            _dbset = context.Set<T>();
            _dbset.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var context = _contextFactory.CreateDbContext();
            _dbset = context.Set<T>();
            var entity = _dbset.Find(id);
            _dbset.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            var context = _contextFactory.CreateDbContext();
            _dbset = context.Set<T>();
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var context = _contextFactory.CreateDbContext();
            _dbset = context.Set<T>();
            return await _dbset.FindAsync(id);
        }

        public async Task<IList<T>> GetFilterAsync(Expression<Func<T, bool>> filter)
        {
            var context = _contextFactory.CreateDbContext();
            _dbset = context.Set<T>();
            return await _dbset.Where(filter).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var context = _contextFactory.CreateDbContext();
            _dbset = context.Set<T>();
            _dbset.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
