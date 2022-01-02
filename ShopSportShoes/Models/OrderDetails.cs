using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public double IntoMoney { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public int ShoeId { get; set; }
        public int OrderId { get; set; }
        public Shoe ShoeNavigation { get; set; }
        public Order OrderNavigation { get; set; }
    }
}
