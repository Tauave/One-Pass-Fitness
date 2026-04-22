using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace One_Pass_Fitness.Models
{
    public class Trainers
    {
        public int Trainersid { get; set; }
        public int Personid { get; set; }

        [Required]
        public string Trainedfield { get; set; }

        public DateOnly Datehired { get; set; }

        public Personalinfo Person { get; set; } = null!;
        public ICollection<Classes> Classes { get; set; } = new List<Classes>();
    }
}
