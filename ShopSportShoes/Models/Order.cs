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
            OrderProgressesNavigation = new();
        }
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCanceled { get; set; }
        public int? UserId { get; set; }
        public virtual User UserNavigation { get; set; }
        public List<OrderDetails> OrdersDetails { get; set; }
        public List<OrderProgress> OrderProgressesNavigation { get; set; }
    }

    public class OrderProgress
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public int OrderId { get; set; }
        public Order OrderNavigation { get; set; }
    }
}
