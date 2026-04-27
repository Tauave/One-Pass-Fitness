namespace One_Pass_Fitness.Models
{
    public class Membership
    {
        public int Membershipid { get; set; }

        public int Userid { get; set; }

        public DateOnly Startdate { get; set; }
        public DateOnly Enddate { get; set; }

        public decimal Price { get; set; }

        public Users User { get; set; } = null!;
    }
}