namespace One_Pass_Fitness.Models
{
    public class Roles
    {
        public int Roleid { get; set; }

        public string Role { get; set; } = null!;

        public ICollection<Users> Users { get; set; } = new List<Users>();
    }
}