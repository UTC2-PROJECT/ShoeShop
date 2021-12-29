using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Models
{
    public class ShoeCatalog
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Loại giày không đươc bỏ trống")]
        public string Name { get; set; }
        public List<Shoe> ShoesNavigation{ get; set; }
    }
}
