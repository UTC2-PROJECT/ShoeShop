using Microsoft.EntityFrameworkCore;
using ShopSportShoes.Data;
using ShopSportShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
