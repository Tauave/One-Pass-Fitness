using One_Pass_Fitness.Data;

namespace One_Pass_Fitness.Models
{
    public class Membership
    {
        public int Membershipid { get; set; }

        public DateOnly Startdate { get; set; }
        public DateOnly Enddate { get; set; }

        public int Personalinfoid { get; set; }
        public Personalinfo Personalinfo { get; set; }
        public Users User { get; internal set; }
    }
}