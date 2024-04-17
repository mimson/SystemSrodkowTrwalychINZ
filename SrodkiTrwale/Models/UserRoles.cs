using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SrodkiTrwale.Models
{    
    
    public class UserRoles
    {
        public int ID { get; set; }
        

        public string Roletype { get; set; }

        public virtual List<Users> Users { get; set; }

        
    }
}