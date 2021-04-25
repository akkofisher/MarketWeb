using DataAccessLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


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
    }
}
