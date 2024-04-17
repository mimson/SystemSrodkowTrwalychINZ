using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SrodkiTrwale.Models.ViewModel
{
    public class FixedAssetDetailsModelView
    {
        public int ID { get; set; }
        public string Categories { get; set; }

        public string UserName { get; set; }

        public string ImageUrl { get; set; }
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfCollections { get; set; }
        public string AmortizationValue { get; set; }
        public decimal CurrentPrice { get; set; }

        public List<SelectListItem> ListOfAmortization { get; set; }
    }
}