using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace One_Pass_Fitness.Models
{

    public class Personalinfo
    {
        public int Personalinfoid { get; set; }

        [DataType(DataType.Text)]
        [StringLength(30)]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [StringLength(30)]
        [Required(ErrorMessage = "Please enter your lastname")]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        [StringLength (10)]
        [Required(ErrorMessage = "Please enter your date of birth")]
        public DateOnly DOB { get; set; }

        [DataType (DataType.EmailAddress)]
        [StringLength (1000)]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }


        [DataType (DataType.PhoneNumber)]
        [StringLength(70)]
        [Required(ErrorMessage = "Please enter your phonenumber")]
        public string Phone { get; set; }

        public ICollection<Member> Members { get; set; } = new List<Member>();
        public ICollection<Trainers> Trainers { get; set; } = new List<Trainers>();
        public ICollection<Manager> Managers { get; set; } = new List<Manager>();
    }
}
