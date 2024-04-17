using System.Collections.Generic;

namespace SrodkiTrwale.Api.Models.Raports
{
    public class UserFixedAssets
    {
        public List<User> Users { get; set; }
        public int AssetsRegisteredInLast30Days { get; set; }
    }
}
