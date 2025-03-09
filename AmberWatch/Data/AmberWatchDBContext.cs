using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmberWatch.Areas.Customer.Models;
using AmberWatch.Models;
using Microsoft.EntityFrameworkCore;

namespace AmberWatch.Data
{
    public class AmberWatchDBContext : DbContext
    {
          public AmberWatchDBContext(DbContextOptions<AmberWatchDBContext> options) : base(options) { }

           protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<AccountModel>()
                .HasKey(p => p.Id);
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<WatchModel>()
                .HasKey(p => p.id_watch);
                base.OnModelCreating(modelBuilder);
                
                modelBuilder.Entity<CartModel>()
                .HasKey(p => p.id_cart);
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<OrderModel>()
                .HasKey(p => p.id_order);
                base.OnModelCreating(modelBuilder);
            }

        public DbSet<AccountModel> tbl_Account { get; set; }
        public DbSet<WatchModel> tbl_Watch { get; set; }
        public DbSet<CartModel> tbl_Cart { get; set; }
        public DbSet<OrderModel> tbl_Order { get; set; }
    }
}