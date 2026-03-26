using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace One_Pass_Fitness.Models
{
    
        
    public class BookingClasses
    {
        public int BookingClassesId { get; set; }
        public int Memberid { get; set; }
        public int Classid { get; set; }
        public DateOnly Bookingdate { get; set; }
        public string Attendancestatus { get; set; }

    }
}
