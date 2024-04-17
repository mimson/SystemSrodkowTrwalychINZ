using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SystemSrodkowTrwalych.Models;

namespace SystemSrodkowTrwalych
{
    public class Users
    {
        public int ID { get; set; }
        [ForeignKey("UserRoles")]
        public int UserRolesID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public virtual UserRoles UserRoles { get; set; }
    }
}