using Microsoft.EntityFrameworkCore;
using ShopSportShoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Data
{
    public class ShoeShopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeCatalog> ShoeCatalogs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Evolution> Evolutions { get; set; }

        public ShoeShopDbContext(DbContextOptions<ShoeShopDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoeSize>().HasKey(sc => new { sc.ShoeId, sc.SizeId});

            modelBuilder.Entity<ShoeSize>().HasOne<Shoe>(s => s.ShoeNavigation)
                .WithMany(s => s.ShoeSizesNavigation)
                .HasForeignKey(ss => ss.ShoeId);

            modelBuilder.Entity<ShoeSize>().HasOne<Size>(s => s.SizeNavigation)
               .WithMany(s => s.ShoeSizesNavigation)
               .HasForeignKey(ss => ss.SizeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
