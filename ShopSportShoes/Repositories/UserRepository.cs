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
    public class UserRepository : BaseRepository<User>
    {
        private readonly IDbContextFactory<ShoeShopDbContext> _contextFactory;
        public UserRepository(IDbContextFactory<ShoeShopDbContext> context) : base(context)
        {
            _contextFactory = context;
        }

        public User GetUserByEmail(string email)
        {
            var context = _contextFactory.CreateDbContext();
            return context.Users.Where(x => x.Email == email)?.FirstOrDefault();
        }

        public List<User> GetFilter(Expression<Func<User, bool>> filter)
        {
            var context = _contextFactory.CreateDbContext();
            return context.Users.Where(filter).ToList();
        }
    }
}
