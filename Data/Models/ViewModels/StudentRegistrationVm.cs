using System;
using System.ComponentModel.DataAnnotations;


namespace UkukhulaAPI.Data.Models.View;

public class StudentRegistrationVm
{
    [Required(ErrorMessage = "Please enter name")]
    public string FirstName { get; set; } = null!;
    [Required(ErrorMessage = "Please enter last name")]

    public string LastName { get; set; } = null!;

    [Required]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "ID number must be exactly 13 digits.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "ID number must contain only digits.")]
    public string Idnumber { get; set; } = null!;

    public int averageMark { get; set; }

    public string CourseOfStudy { get; set; }
    public int race { get; set; }
    public int HODId { get; set; }

    
    public string ApplicationMotivation { get; set; }
  
    public decimal BursaryAmount { get; set; }



}