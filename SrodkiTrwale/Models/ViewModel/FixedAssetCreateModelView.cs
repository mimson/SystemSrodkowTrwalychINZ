using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SrodkiTrwale.Models.ViewModel
{
    public class FixedAssetCreateModelView
    {
        public int CategoriesID { get; set; }

        public int UserID { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Nazwa jest za długa")]
        public string Name { get; set; }
        public decimal AmortizationValue { get; set; }
        public decimal PurchasePrice { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfCollections { get; set; }
    }
}