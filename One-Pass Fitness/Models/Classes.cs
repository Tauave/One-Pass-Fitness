using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace One_Pass_Fitness.Models
{
    public class Classes
    {
        public int ClassesId { get; set; }
        [Required]
        [StringLength(100)]
        public string Classname { get; set; }
        
        public DateOnly Date { get; set; }
        public TimeOnly Starttime { get; set; }
        public TimeOnly Endtime { get; set; }
        public int RoleId { get; set; }
        public string? Availability { get; set; }

        public Roles Role { get; set; } = null!;
        //public ICollection<BookingClasses> Bookings { get; set; } = new List<BookingClasses>();
    }
}
