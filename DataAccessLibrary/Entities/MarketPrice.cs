using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Entities
{
    public class MarketPrice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        //[ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [Required]
       // [ForeignKey("MarketId")]
        public virtual Market Market { get; set; }

        [Required]
        [ForeignKey("Market")]
        public int MarketId { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateUpdated { get; set; }
    }
}
