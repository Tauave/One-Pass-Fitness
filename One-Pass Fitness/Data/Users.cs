using Microsoft.AspNetCore.Identity;
using One_Pass_Fitness.Models;

namespace One_Pass_Fitness.Data
{
    public class Users : IdentityUser
    {
        public int Usersid { get; set; }

        public int Personid { get; set; }
        public int RoleId { get; set; }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public Personalinfo Person { get; set; } = null!;
      

        public ICollection<Classes> Classes { get; set; } = new List<Classes>();
        public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    }
}