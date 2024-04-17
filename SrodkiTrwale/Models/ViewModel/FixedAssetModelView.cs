using System;

namespace SrodkiTrwale.Models.ViewModel
{
    public class FixedAssetModelView
    {
        public int id { get; set; }
        public int categoriesId { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public DateTime dateOfCollections { get; set; }
        public int? amortizationId { get; set; }
        public string imageUrl { get; set; }
    }
}