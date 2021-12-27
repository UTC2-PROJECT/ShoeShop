using Microsoft.EntityFrameworkCore;
using ShopSportShoes.Data;
using ShopSportShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        private readonly IDbContextFactory<ShoeShopDbContext> _contextFactory;
        public UserRepository(IDbContextFactory<ShoeShopDbContext> context) : base(context)
        {
            _contextFactory = context;
        }
    }
}
