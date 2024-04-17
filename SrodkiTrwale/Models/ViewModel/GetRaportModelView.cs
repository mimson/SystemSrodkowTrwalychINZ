using System.Collections.Generic;

namespace SrodkiTrwale.Models.ViewModel
{
    public class GetRaportModelView
    {
        public int id { get; set; }
        public int userRolesId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string imageUrl { get; set; }
        public List<FixedAssetModelView> fixedAssets { get; set; }
    }
}