using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Models
{
    public class Evolution
    {
        public int Id { get; set; }
        public int NumberOfStar { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int ShoeId { get; set; }
        public Shoe ShoeNavigation { get; set; }
        public User UserNavigation { get; set; }
    }
}
