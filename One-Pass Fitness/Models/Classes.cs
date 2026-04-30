using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace One_Pass_Fitness.Models
{
    public class Classes
    {
        public int ClassesId { get; set; }
        //A classname is required and should not exceed 30 characters in length.
        //The error message "Please enter a classname" will be displayed if the validation fails.
        //Anything that is not a text will not be accepted as a valid classname, and the classname must be at least 3 characters long.
        [DataType(DataType.Text)]
        [StringLength(30), MinLength(3)]
        public string Classname { get; set; }


        //When a class is set a date for the class is required.
        //The error message "Please enter a date for the class" will be displayed if the validation fails.
        [Required(ErrorMessage = "Please enter a date for the class")]
        public DateOnly Date { get; set; }


        //When a class is set a start time for the class is required
        //The error message "Please enter a start time for the class" will be displayed if the validation fails.
        [Required(ErrorMessage = "Please enter a start time for the class")]
        public TimeOnly Starttime { get; set; }


        //When a class is set an end time for the class is required
        //The error message "Please enter an end time for the class" will be displayed if the validation fails.
        //Setting an end time that is before the start time will not be accepted as a valid end time for the class.
        [Required(ErrorMessage = "Please enter an end time for the class")]
        public TimeOnly Endtime { get; set; }

        public int UserId { get; set; }

        //A class needs to have an availability status when it has been created.
        //A required attribute is used to ensure that the availability field is not left empty when creating a class.
        //Else a class will just show up with no availability status, which can lead to confusion for users who are trying to sign up for classes.
        [Required(ErrorMessage = "Please enter an availability status for the class")]
        public string? Availability { get; set; }

        public Users User { get; set; } 
    }
}
