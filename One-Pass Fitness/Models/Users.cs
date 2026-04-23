namespace One_Pass_Fitness.Models
{
    public class Users
    {
        public int Usersid { get; set; }

        public int Personid { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public Personalinfo Person { get; set; } = null!;
    }
}
