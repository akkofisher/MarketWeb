using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Entities
{
    public class MarketPrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public Company Company { get; set; }
        [Required]
        public int CompanyId { get; set; }

        [Required]
        public Market Market { get; set; }
        [Required]
        public int MarketId { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateUpdated { get; set; }
    }
}
