using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Services
{
    public interface IMarketService
    {
        Task<IEnumerable<Market>> GetMarkets();
        Task<Market> GetMarketById(int Id);
    }

    public class MarketService : IMarketService
    {
        private MarketContext _marketContext;

        public MarketService(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        public async Task<IEnumerable<Market>> GetMarkets()
        {
            return await _marketContext.Markets.ToListAsync();
        }

        public async Task<Market> GetMarketById(int Id)
        {
            return await _marketContext.Markets.FindAsync(Id);
        }

    }
}
