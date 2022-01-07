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
                                 .Include(x => x.OrderProgressesNavigation)
                                 .ToList();
        }
        public Order GetById(int id)
        {
            var context = _contextFactory.CreateDbContext();
            return context.Orders.Where(x => x.Id == id)
                                 .Include(x => x.OrdersDetails)
                                    .ThenInclude(x => x.ShoeNavigation.ImagesNavigation)
                                 .Include(x => x.OrdersDetails)
                                    .ThenInclude(x => x.ShoeNavigation.ShoeCatalogNavigation)
                                 .Include(x => x.UserNavigation)
                                 .Include(x => x.OrderProgressesNavigation)
                                 .FirstOrDefault();
        }


        public void Update(Order order)
        {
            var context = _contextFactory.CreateDbContext();
            context.Entry(order).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
