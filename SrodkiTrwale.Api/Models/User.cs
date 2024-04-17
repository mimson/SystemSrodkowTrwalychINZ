using System;
using System.Collections.Generic;

#nullable disable

namespace SrodkiTrwale.Api.Models
{
    public partial class User
    {
        public User()
        {
            FixedAssets = new HashSet<FixedAsset>();
            Raports = new HashSet<Raport>();
        }

        public int Id { get; set; }
        public int UserRolesId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }

        public virtual UserRole UserRoles { get; set; }
        public virtual ICollection<FixedAsset> FixedAssets { get; set; }
        public virtual ICollection<Raport> Raports { get; set; }
    }
}
