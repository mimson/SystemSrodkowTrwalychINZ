namespace SrodkiTrwale.Models.ViewModel
{
    public class UserDetailsModelView
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
        public string ImageUrl { get; set; }

        public virtual UserRoles UserRoles { get; set; }
    }
}