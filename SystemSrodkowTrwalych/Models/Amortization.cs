using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemSrodkowTrwalych.Models
{
    public class Amortization
    {

        public int ID { get; set; }
       [ForeignKey("FixedAssets")]
        public int FixedAssetsID { get; set; }
        public int AmortizationValue { get; set; }

        public DateTime ModificationDate { get; set; }

        public string Description { get; set; }

        public virtual List<FixedAssets> FixedAssets { get; set; }
        public virtual List<AmortizationRow> AmortizationRows { get; set; }


    }
}