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
    public class OrderDetailsRepository : BaseRepository<OrderDetails>
    {
        private readonly IDbContextFactory<ShoeShopDbContext> _contextFactory;
        public OrderDetailsRepository(IDbContextFactory<ShoeShopDbContext> context) : base(context)
        {
            _contextFactory = context;
        }

        public List<OrderDetails> GetFilterCustomize(Expression<Func<OrderDetails, bool>> filter)
        {
            var context = _contextFactory.CreateDbContext();
            return context.OrderDetails.Where(filter)
                                       .Include(x => x.ShoeNavigation.ImagesNavigation)
                                       .Include(x => x.ShoeNavigation.ShoeCatalogNavigation)
                                       .ToList();
        }

        public void Update(OrderDetails orderDetails)
        {
            var context = _contextFactory.CreateDbContext();
            context.Entry(orderDetails).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
