using System;
using System.ComponentModel.DataAnnotations;


namespace UkukhulaAPI.Data.Models.View;

public class StudentUpdateVm
{
   
    [Required]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "ID number must be exactly 13 digits.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "ID number must contain only digits.")]
    public string Idnumber { get; set; } = null!;

    public int averageMark { get; set; }

    public string ApplicationMotivation { get; set; }
  
    public decimal BursaryAmount { get; set; }



}