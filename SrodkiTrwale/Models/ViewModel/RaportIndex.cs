using System.Collections.Generic;

namespace SrodkiTrwale.Models.ViewModel
{
    public class RaportIndex
    {
        public List<RaportIndexUser> Users { get; set; } = new List<RaportIndexUser>();
        public int last30DaysFixedAssets { get; set; }
    }

    public class RaportIndexUser
    {
        public string name { get; set; }
        public int fixedAssetsCount { get; set; }
    }
}
