using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            }

        public DbSet<AccountModel> tbl_Account { get; set; }
    }
}