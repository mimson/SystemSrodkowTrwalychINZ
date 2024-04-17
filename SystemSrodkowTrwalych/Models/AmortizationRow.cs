using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemSrodkowTrwalych.Models
{
    public class AmortizationRow
    {
        public int ID { get; set; }
        [ForeignKey("Amortization")]
        public int AmortizationId { get; set; }
        public virtual Amortization Amortization { get; set; }
        [ForeignKey("FixedAsset")]
        public int FixedAssetId { get; set; }
        public virtual FixedAssets FixedAsset { get; set; }
    }
}