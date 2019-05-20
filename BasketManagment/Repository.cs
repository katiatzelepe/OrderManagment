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
                .UseSqlServer(@"Server=localhost;Database=OrderManagment2; Trusted_Connection = True; ConnectRetryCount = 0;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         // modelBuilder.Entity<Product>();
            modelBuilder.Entity<Product>().HasMany(p => p.baskets); // me sxeseis

            //    modelBuilder.Entity<Basket>();
            modelBuilder.Entity<Basket>().HasOne(p => p.Customer);
            modelBuilder.Entity<Basket>().HasMany(b => b.Cart);

            modelBuilder.Entity<Customer>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Customer>().HasMany(p => p.PreviousBaskets);
            

        }
    }
}
