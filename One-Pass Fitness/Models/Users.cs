namespace One_Pass_Fitness.Models
{
    public class Users
    {
        public int Usersid { get; set; }

        public int Personid { get; set; }
        public int RoleId { get; set; }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public Personalinfo Person { get; set; } = null!;
        public Roles Role { get; set; } = null!;

        public ICollection<Classes> Classes { get; set; } = new List<Classes>();
        public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    }
}