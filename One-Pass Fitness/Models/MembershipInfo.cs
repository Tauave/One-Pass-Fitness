using System;
using System.Collections.Generic;

namespace One_Pass_Fitness.Models
{
    public class MembershipInfo
    {
        public int MembershipInfoid { get; set; }
        public int Memberid { get; set; }
        public DateOnly Startdate { get; set; }
        public DateOnly Enddate { get; set; }
        public decimal Price { get; set; }

    }
}
