using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SystemSrodkowTrwalych.Models
{
    public class FixedAssets
    {
        [Key]
        public int ID { get; set; }
      
        [ForeignKey("Categories")]
        public int CategoriesID { get; set; }
        [ForeignKey("Users")]
        public int UserID { get; set; }
        public string Name { get; set; }

        public DateTime DateOfCollections { get; set; }

        public virtual Users Users { get; set; }

        public virtual Categories Categories { get; set; }

      



    }
}