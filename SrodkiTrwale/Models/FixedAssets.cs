using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SrodkiTrwale.Models
{
    public class FixedAssets
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Categories")]
        public int CategoriesID { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }

        public string ImageUrl { get; set; }
        public decimal AmortizationValue { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal CurrentPrice { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Nazwa jest za długa")]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfCollections { get; set; }

        public virtual Users Users { get; set; }
        public virtual Categories Categories { get; set; }
    }
}