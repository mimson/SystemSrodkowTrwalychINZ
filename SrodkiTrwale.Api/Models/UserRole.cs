using System;
using System.Collections.Generic;

#nullable disable

namespace SrodkiTrwale.Api.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Roletype { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
