using KariyerNet.Core.Models;
using KariyerNet.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data
{
    public class KariyerDbContext: DbContext
    {
        public KariyerDbContext(DbContextOptions<KariyerDbContext> options ):base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }
    }

}
