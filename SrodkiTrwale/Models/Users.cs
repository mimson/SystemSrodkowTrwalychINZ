using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SrodkiTrwale.Models
{
    public class Users
    {
        public int ID { get; set; }
        [ForeignKey("UserRoles")]
        public int UserRolesID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [Display(AutoGenerateField =false)]
        public string Password { get; set; }
        public string ImageUrl { get; set; }

        public virtual UserRoles UserRoles { get; set; }
    }
}