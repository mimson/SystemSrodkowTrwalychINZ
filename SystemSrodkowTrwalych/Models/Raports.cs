using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemSrodkowTrwalych.Models;

namespace SystemSrodkowTrwalych
{
    public class Raports
    {
        public int ID { get; set; }

        public DateTime CreactionDate { get; set; }

        public string Description { get; set; }


        public virtual Users Users { get; set; }

        public virtual FixedAssets FixedAssets { get; set; }




    }
}