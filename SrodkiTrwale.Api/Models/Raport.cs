using System;
using System.Collections.Generic;

#nullable disable

namespace SrodkiTrwale.Api.Models
{
    public partial class Raport
    {
        public int Id { get; set; }
        public DateTime CreactionDate { get; set; }
        public string Description { get; set; }
        public int? FixedAssetsId { get; set; }
        public int? UsersId { get; set; }

        public virtual FixedAsset FixedAssets { get; set; }
        public virtual User Users { get; set; }
    }
}
