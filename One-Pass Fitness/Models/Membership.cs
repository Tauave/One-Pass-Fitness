namespace One_Pass_Fitness.Models
{
    /// <summary>
    /// A priced membership period for a member (separate from the Member subtype row).
    /// </summary>
    public class Membership
    {
        public int Membershipid { get; set; }
        public int Memberid { get; set; }
        public string MembershipType { get; set; } = null!;
        public DateOnly Startdate { get; set; }
        public DateOnly Enddate { get; set; }
        public decimal Price { get; set; }

        public Member Member { get; set; } = null!;
    }
}
