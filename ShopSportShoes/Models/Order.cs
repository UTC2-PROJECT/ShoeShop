using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Models
{
    public class Order
    {
        public Order()
        {
            OrdersDetails = new();
        }
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCanceled { get; set; }
        public int UserId { get; set; }
        public User UserNavigation { get; set; }
        public List<OrderDetails> OrdersDetails { get; set; }
    }
}
