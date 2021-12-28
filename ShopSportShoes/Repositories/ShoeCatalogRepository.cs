using Microsoft.EntityFrameworkCore;
using ShopSportShoes.Data;
using ShopSportShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Repositories
{
    public class ShoeCatalogRepository : BaseRepository<ShoeCatalog>
    {
        private readonly IDbContextFactory<ShoeShopDbContext> _contextFactory;
        public ShoeCatalogRepository(IDbContextFactory<ShoeShopDbContext> context) : base(context)
        {
            _contextFactory = context;
        }
    }
}
