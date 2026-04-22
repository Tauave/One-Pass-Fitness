using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace One_Pass_Fitness.Models
{

    public class Personalinfo
    {
        public int Personalinfoid { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Lastname { get; set; }

        [Required]
        [StringLength (10)]
        public DateOnly DOB { get; set; }

        [Required]
        [EmailAddress]
        [StringLength (1000)]
        public string Email { get; set; }
        [Required]
        [Phone]
        [StringLength(70)]
        public string Phone { get; set; }

        public ICollection<Member> Members { get; set; } = new List<Member>();
        public ICollection<Trainers> Trainers { get; set; } = new List<Trainers>();
        public ICollection<Manager> Managers { get; set; } = new List<Manager>();
    }
}
