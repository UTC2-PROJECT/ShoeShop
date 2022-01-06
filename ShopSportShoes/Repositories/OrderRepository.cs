using Microsoft.EntityFrameworkCore;
using ShopSportShoes.Data;
using ShopSportShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        private readonly IDbContextFactory<ShoeShopDbContext> _contextFactory;
        public OrderRepository(IDbContextFactory<ShoeShopDbContext> context) : base(context)
        {
            _contextFactory = context;
        }

        public List<Order> GetAllCustom()
        {
            var context = _contextFactory.CreateDbContext();
            return context.Orders.OrderByDescending(x => x.DateCreated)
                                 .Include(x => x.OrdersDetails)
                                    .ThenInclude(x => x.ShoeNavigation.ImagesNavigation)
                                 .Include(x => x.OrdersDetails)
                                    .ThenInclude(x => x.ShoeNavigation.ShoeCatalogNavigation)
                                 .Include(x => x.UserNavigation)
                                 .ToList();
        }
    }
}
