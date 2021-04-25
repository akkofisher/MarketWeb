using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Entities;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompanyById(int Id);
        Task<IEnumerable<object>> GetCompanyPrices();
        Task<IEnumerable<object>> GetPricesByCompanyId(int Id);
        Task<bool> AddOrUpdateCompanyPrice(CompanyPriceModel data);
    }

    public class CompanyService : ICompanyService
    {
        private MarketContext _marketContext;

        public CompanyService(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _marketContext.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyById(int Id)
        {
            return await _marketContext.Companies.FindAsync(Id);
        }

        public async Task<IEnumerable<Object>> GetCompanyPrices()
        {
            return await _marketContext.MarketPrices.Select(x => new
            {
                Id = x.Id,
                Price = x.Price,
                CompanyName = x.Company.Name,
                CompanyId = x.Company.Id,
                MarketName = x.Market.Name,
                MarketId = x.Market.Id,
            }).ToListAsync();
        }

        public async Task<IEnumerable<object>> GetPricesByCompanyId(int Id)
        {
            return await _marketContext.MarketPrices.Where(x => x.Company.Id == Id).
                Select(x => new
                {
                    Id = x.Id,
                    Price = x.Price,
                    CompanyName = x.Company.Name,
                    CompanyId = x.Company.Id,
                    MarketName = x.Market.Name,
                    MarketId = x.Market.Id,
                }).ToListAsync();
        }

        public async Task<bool> AddOrUpdateCompanyPrice(CompanyPriceModel data)
        {
            var foundCompany = await _marketContext.MarketPrices.FirstOrDefaultAsync(x => x.Company.Id == data.CompanyId && x.Market.Id == data.MarketId);

            if (foundCompany != null)
            {
                foundCompany.Price = data.Price;
                foundCompany.DateUpdated = DateTime.Now;

                _marketContext.Attach(foundCompany);
                _marketContext.Entry(foundCompany).Property(p => p.Price).IsModified = true;
                _marketContext.Entry(foundCompany).Property(p => p.DateUpdated).IsModified = true;

                await _marketContext.SaveChangesAsync();
            }
            else
            {
                await _marketContext.MarketPrices.AddAsync(new MarketPrice
                {
                    CompanyId = data.CompanyId,
                    MarketId = data.MarketId,
                    Price = data.Price,
                    DateUpdated = DateTime.Now
                });
                await _marketContext.SaveChangesAsync();
            }

            return true;
        }

    }
}
