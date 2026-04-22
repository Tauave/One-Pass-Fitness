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
        [Required]
        [Date
        public DateOnly Date { get; set; }
        public TimeOnly Starttime { get; set; }
        public TimeOnly Endtime { get; set; }
        public int Trainerid { get; set; }
        public string? Availability { get; set; }

        public Trainers Trainer { get; set; } = null!;
        public ICollection<BookingClasses> Bookings { get; set; } = new List<BookingClasses>();
    }
}
