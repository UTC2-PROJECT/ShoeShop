using Microsoft.EntityFrameworkCore;
using ShopSportShoes.Data;
using ShopSportShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Repositories
{
    public class EvolutionRepository : BaseRepository<Evolution>
    {
        private readonly IDbContextFactory<ShoeShopDbContext> _contextFactory;
        public EvolutionRepository(IDbContextFactory<ShoeShopDbContext> context) : base(context)
        {
            _contextFactory = context;
        }

        public List<Evolution> GetAll()
        {
            var context = _contextFactory.CreateDbContext();
            return context.Evolutions.Include(x => x.UserNavigation)
                                     .Include(x => x.ShoeNavigation)
                                     .ToList();
        }
    }
}
