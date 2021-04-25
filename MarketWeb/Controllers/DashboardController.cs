using DataAccessLibrary.Models;
using DataAccessLibrary.Services;
using MarketWeb.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketWeb.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;

        private ICompanyService _companyService;
        private IMarketService _marketService;
        private ICacheManager _cacheManager;


        public DashboardController(
            ILogger<DashboardController> logger,
            ICompanyService companyService,
            IMarketService marketService,
            ICacheManager cacheManager)
        {
            _logger = logger;
            _companyService = companyService;
            _marketService = marketService;
            _cacheManager = cacheManager;
        }


        [HttpGet("GetNames")]
        public async Task<IActionResult> GetNames()
        {
            var namelist = await _cacheManager.Get("companies&markets", async () =>
            {
                return new
                {
                    Companies = await _companyService.GetCompanies(),
                    Markets = await _marketService.GetMarkets(),
                };
            });

            return Ok(namelist);
        }


        [HttpGet("GetCompanyPrices")]
        public async Task<IActionResult> GetCompanyPrices()
        {
            return Ok(await _companyService.GetCompanyPrices());
        }


        [HttpGet("GetCompanyById")]
        public async Task<IActionResult> GetCompanyById(int Id)
        {
            return Ok(await _companyService.GetCompanyById(Id));
        }


        [HttpGet("GetPricesByCompanyId")]
        public async Task<IActionResult> GetPricesByCompanyId(int Id)
        {
            return Ok(await _companyService.GetPricesByCompanyId(Id));
        }

        [HttpPost("AddOrUpdateCompanyPrice")]
        public async Task<IActionResult> AddOrUpdateCompanyPrice([FromForm] CompanyPriceModel data)
        {
            return Ok(await _companyService.AddOrUpdateCompanyPrice(data));
        }
    }
}
