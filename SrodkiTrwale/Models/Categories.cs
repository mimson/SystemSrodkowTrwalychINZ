using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SrodkiTrwale.Models
{
    
    public class Categories
    {
        public int ID { get; set; }
     
        public string CatTypes { get; set; }

        public virtual List<FixedAssets> FixedAssets { get; set; }

        

    }
}