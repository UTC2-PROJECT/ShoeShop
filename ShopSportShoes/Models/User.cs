using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Models
{
    public class User
    {
        public User()
        {
            Roles = new();
            EvolutionNavigations = new();
            OrdersNavigation = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsAdmin { get; set; }
        public List<Order> OrdersNavigation { get; set; }
        public List<Evolution> EvolutionNavigations { get; set; }
        public List<OrderDetails> OrdersDetailsNavigation { get; set; }

        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string RePassword { get; set; }
        [NotMapped]
        public List<string> Roles { get; set; }
    }
}
