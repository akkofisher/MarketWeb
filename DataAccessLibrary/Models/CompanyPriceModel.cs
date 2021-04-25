using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class CompanyPriceModel
    {
        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int MarketId { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
