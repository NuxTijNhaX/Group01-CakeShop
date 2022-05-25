using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Data
{
    public class CakeShopDbContext : DbContext
    {
        public CakeShopDbContext(DbContextOptions options) : base(options) { }

        //public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Size> Sizes { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(u => u.PhoneNumber).IsUnique();
        }
    }
}
