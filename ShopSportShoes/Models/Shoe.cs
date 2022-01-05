using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShopSportShoes.Models
{
    public class Shoe
    {
        public Shoe()
        {
            ShoeSizesNavigation = new();
            ImagesNavigation = new();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Trademark { get; set; }
        public int Quantity { get; set; }
        public int ShoeCatalogId { get; set; }
        public ShoeCatalog ShoeCatalogNavigation { get; set; }
        public List<ShoeSize> ShoeSizesNavigation { get; set; }
        public List<Image> ImagesNavigation { get; set; }
    }

    public class Size
    {
        public int Id { get; set; }
        public string SizeName { get; set; }
        public IList<ShoeSize> ShoeSizesNavigation { get; set; }
    }

    public class ShoeSize
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public Shoe ShoeNavigation { get; set; }
        public int SizeId { get; set; }
        public Size SizeNavigation { get; set; }
    }

    public class Image
    {
        public int Id { get; set; }
        [MaxLength(int.MaxValue)]
        public string ImageSource { get; set; }
        public int ShoeId { get; set; }
        public Shoe ShoeNavigation { get; set; }
    }

}
