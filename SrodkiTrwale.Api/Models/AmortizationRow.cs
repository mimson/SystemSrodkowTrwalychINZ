using System;
using System.Collections.Generic;

#nullable disable

namespace SrodkiTrwale.Api.Models
{
    public partial class AmortizationRow
    {
        public int Id { get; set; }
        public int AmortizationId { get; set; }
        public int FixedAssetId { get; set; }

        public virtual Amortization Amortization { get; set; }
        public virtual FixedAsset FixedAsset { get; set; }
    }
}
