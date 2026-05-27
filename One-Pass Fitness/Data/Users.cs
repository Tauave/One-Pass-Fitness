using One_Pass_Fitness.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace One_Pass_Fitness.Data
{
    public class Users:IdentityUser

    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public int Password { get; set; }

        public Membership Membership { get; set; }
        //public string? Id { get; internal set; }
    }
}
