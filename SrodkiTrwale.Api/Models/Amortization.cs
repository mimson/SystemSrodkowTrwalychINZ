using System;
using System.Collections.Generic;

#nullable disable

namespace SrodkiTrwale.Api.Models
{
    public partial class Amortization
    {
        public Amortization()
        {
            AmortizationRows = new HashSet<AmortizationRow>();
            FixedAssets = new HashSet<FixedAsset>();
        }

        public int Id { get; set; }
        public int FixedAssetsId { get; set; }
        public int AmortizationValue { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AmortizationRow> AmortizationRows { get; set; }
        public virtual ICollection<FixedAsset> FixedAssets { get; set; }
    }
}
