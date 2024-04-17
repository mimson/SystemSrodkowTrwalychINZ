using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SrodkiTrwale.Models
{
    public class Amortization
    {

        public int ID { get; set; }
       [ForeignKey("FixedAssets")]
        public int FixedAssetsID { get; set; }
        [Range(1,100,ErrorMessage ="Podaj wartość od 1 do 100")]
        public int AmortizationValue { get; set; }

        public DateTime ModificationDate { get; set; }
        [StringLength(200,ErrorMessage ="Maksymalna ilosc znaków to 200")]
        public string Description { get; set; }

        public virtual List<FixedAssets> FixedAssets { get; set; }
        public virtual List<AmortizationRow> AmortizationRows { get; set; }


    }
}