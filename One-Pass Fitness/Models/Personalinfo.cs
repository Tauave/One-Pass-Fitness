using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace One_Pass_Fitness.Models
{

    public class Personalinfo
    {
        public int Personalinfoid { get; set; }

        //A name is required and should not exceed 30 characters in length. The error message "Please enter your name" will be displayed if the validation fails.
        //Anything that is not a text will not be accepted as a valid name, and the name must be at least 3 characters long.
        [DataType(DataType.Text)]
        [StringLength(30), MinLength(3)]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        //A lastname is required and should not exceed 30 characters in length. The error message "Please enter your lastname" will be displayed if the validation fails.
        //Anything that is not a text will not be accepted as a valid lastname, and the lastname must be at least 3 characters long.
        [DataType(DataType.Text)]
        [StringLength(30), MinLength(3)]
        [Required(ErrorMessage = "Please enter your lastname")]
        public string Lastname { get; set; } 

        //A date of birth is required and should be in the format of a date. The error message "Please enter your date of birth" will be displayed if the validation fails.
        [Required(ErrorMessage = "Please enter your date of birth")]
        public DateOnly DOB { get; set; }

        //An email address is required and should be in the format of an email address. The error message "Please enter your email" will be displayed if the validation fails.
        //The email address should not exceed 1000 characters in length.
        //The datatype attribute ensures that the input is treated as an email address, and the string length attribute limits the length of the email address to 1000 characters.
        //The required attribute ensures that the email field is not left empty.
        [DataType (DataType.EmailAddress)]
        [StringLength (1000)]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        //A phone number is required and should be in the format of a phone number. The error message "Please enter your phonenumber" will be displayed if the validation fails.
        //The phone number should not exceed 70 characters in length.
        [DataType (DataType.PhoneNumber)]
        [StringLength(70)]
        [Required(ErrorMessage = "Please enter your phonenumber")]
        public string Phone { get; set; }
        public Users User { get; set; } 

    }
}
