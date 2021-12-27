using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsAdmin { get; set; }
        public List<Order> OrdersNavigation { get; set; }
        public List<Evolution> EvolutionsNavigation { get; set; }
    }
}
