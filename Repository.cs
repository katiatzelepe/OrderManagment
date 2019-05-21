using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketManagment
{
    public class Repository : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public DbSet<Basket> Basket { get; set; }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=localhost;Database=TestOrderManagment; Trusted_Connection = True; ConnectRetryCount = 0;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Basket>()
                  .HasOne(b => b.Customer)
                  .WithMany(c => c.baskets)
                  .HasForeignKey(b => b.customerId);
            modelBuilder.Entity<BasketProduct>()
                .HasKey(t => new { t.BasketId, t.ProductId });
            modelBuilder.Entity<BasketProduct>()
                .HasOne(pt => pt.basket)
                .WithMany(p => p.basketproducts)
                .HasForeignKey(pt => pt.BasketId);
            modelBuilder.Entity<BasketProduct>()
                .HasOne(pt => pt.product)
                .WithMany(t => t.basketproducts)
                .HasForeignKey(pt => pt.ProductId);



        }
    }
}
