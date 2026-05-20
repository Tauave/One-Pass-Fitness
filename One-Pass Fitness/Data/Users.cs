using One_Pass_Fitness.Models;

namespace One_Pass_Fitness.Data
{
    public class Users
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public int Password { get; set; }

        public Membership Membership { get; set; }
    }
}
