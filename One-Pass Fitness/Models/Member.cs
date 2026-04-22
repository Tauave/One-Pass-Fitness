using System.Collections.Generic;

namespace One_Pass_Fitness.Models
{
    public class Member
    {
        public int Memberid { get; set; }
        public int Personid { get; set; }
        
        public DateOnly Datejoined { get; set; }

        public string? Status { get; set; }

        public Personalinfo Person { get; set; } = null!;
        public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    }
}
