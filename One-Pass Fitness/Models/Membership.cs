namespace One_Pass_Fitness.Models
{

    public class Membership
    {
        public int Membershipid { get; set; }
        public int Roleid { get; set; }
        public string MembershipType { get; set; } 
        public DateOnly Startdate { get; set; }
        public DateOnly Enddate { get; set; }
        public decimal Price { get; set; }

        public Roles Roles { get; set; } 
    }
}
