using System;

namespace SrodkiTrwale.Api.ApiModels
{
    public class FixedAssetApiModel
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string userName { get; set; }
        public string name { get; set; }
        public DateTime dateOfCollections { get; set; }
    }
}
