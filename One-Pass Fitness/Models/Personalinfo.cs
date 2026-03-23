using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace One_Pass_Fitness.Models
{
    public class Personalinfo
    {
        public int Personid { get; set; }
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Lastname { get; set; }
        [Required]
        [StringLength (100)]

        public DateOnly DOB { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Phone { get; set; }


    }
}
