using System;
using System.Collections.Generic;

namespace One_Pass_Fitness.Models
{
    public class Classes
    {
        public int ClassesId { get; set; }
        public string Classname { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Starttime { get; set; }
        public TimeOnly Endtime { get; set; }
        public int Trainerid { get; set; }
        public string? Availability { get; set; }

    }
}
