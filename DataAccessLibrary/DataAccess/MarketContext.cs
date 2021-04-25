using DataAccessLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DataAccessLibrary.DataAccess
{
    public class MarketContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MarketContext(IConfiguration configuration) { Configuration = configuration; }
        //public MarketContext(DbContextOptions options, IConfiguration configuration) : base(options) { Configuration = configuration; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("Default"));
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<MarketPrice> MarketPrices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Company
            modelBuilder.Entity<Company>()
                        .HasData(
                         new Company { Id = 1000, Name = "Company 1", Code = "C1" },
                         new Company { Id = 1001, Name = "Company 2", Code = "C2" },
                         new Company { Id = 1002, Name = "Company 3", Code = "C3" },
                         new Company { Id = 1003, Name = "Company 4", Code = "C4" },
                         new Company { Id = 1004, Name = "Company 5", Code = "C5" }
                         );

            //Market
            modelBuilder.Entity<Market>()
                        .HasData(
                         new Market { Id = 1000, Name = "Market 1", Code = "M1" },
                         new Market { Id = 1001, Name = "Market 2", Code = "M2" },
                         new Market { Id = 1002, Name = "Market 3", Code = "M3" },
                         new Market { Id = 1003, Name = "Market 4", Code = "M4" },
                         new Market { Id = 1004, Name = "Market 5", Code = "M5" }
                         );

            //MarketPrice
            //modelBuilder.Entity<MarketPrice>()
            //            .HasData(
            //             new MarketPrice { Id = 1000, MarketId = 1, CompanyId = 1, Price = 100, DateUpdated = DateTime.Now },
            //             new MarketPrice { Id = 1001, MarketId = 1, CompanyId = 1, Price = 200, DateUpdated = DateTime.Now },
            //             new MarketPrice { Id = 1002, MarketId = 1, CompanyId = 2, Price = 300, DateUpdated = DateTime.Now }
            //             );
        }
    }
}
