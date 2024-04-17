using System;
using System.Collections.Generic;

#nullable disable

namespace SrodkiTrwale.Api.Models
{
    public partial class Category
    {
        public Category()
        {
            FixedAssets = new HashSet<FixedAsset>();
        }

        public int Id { get; set; }
        public string CatTypes { get; set; }

        public virtual ICollection<FixedAsset> FixedAssets { get; set; }
    }
}
