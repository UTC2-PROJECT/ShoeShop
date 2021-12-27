using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Models
{
    public class ShoeCatalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Shoe> ShoesNavigation{ get; set; }
    }
}
