using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SrodkiTrwale.Models.ApiModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class FixedAssetApiModel
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string userName { get; set; }
        public string name { get; set; }
        public DateTime dateOfCollections { get; set; }
      
    }
}