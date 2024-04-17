using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SrodkiTrwale.Models.ViewModel
{
    public class UserEditViewModel
    {

        public int Id { get; set; }
        public int UserRolesID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public virtual UserRoles UserRoles { get; set; }
    }
}