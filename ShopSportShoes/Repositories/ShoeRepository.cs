using Microsoft.EntityFrameworkCore;
using ShopSportShoes.Data;
using ShopSportShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopSportShoes.Repositories
{
    public class ShoeRepository : BaseRepository<Shoe>
    {
        private readonly IDbContextFactory<ShoeShopDbContext> _contextFactory;
        public ShoeRepository(IDbContextFactory<ShoeShopDbContext> context) : base(context)
        {
            _contextFactory = context;
        }

        public async Task<List<Shoe>> GetAllLoadingAsync()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Shoes.Include(x => x.ImagesNavigation)
                                      .Include(x => x.ShoeSizesNavigation)
                                        .ThenInclude(x => x.SizeNavigation)
                                      .Include(x => x.ShoeCatalogNavigation)
                                      .ToListAsync();
        }

        public async Task<List<Shoe>> GetFilterCustomizeAsync(Expression<Func<Shoe, bool>> filter)
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Shoes.Where(filter).Include(x => x.ImagesNavigation)
                                      .Include(x => x.ShoeSizesNavigation)
                                        .ThenInclude(x => x.SizeNavigation)
                                      .Include(x => x.ShoeCatalogNavigation)
                                      .ToListAsync();
        }

        public async Task<Shoe> GetByIdDetailsAsync(int id)
        {
            var context = _contextFactory.CreateDbContext();

            return await context.Shoes.Where(x => x.Id == id)
                                    .Include(x => x.ImagesNavigation)
                                    .Include(x => x.ShoeCatalogNavigation)
                                    .Include(x => x.ShoeSizesNavigation)
                                        .ThenInclude(x => x.SizeNavigation)
                                    .FirstOrDefaultAsync();
        }

        public async Task<Shoe> UpdateCustomizeAsync(Shoe shoe)
        {
            var context = _contextFactory.CreateDbContext();
            context.Shoes.Update(shoe);
            await context.SaveChangesAsync();
            return shoe;
        }
    }
}
