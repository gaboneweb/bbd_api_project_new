using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;


namespace UkukhulaAPI.Data.Models.View;

public class UniversityApplicationVM
{
    public string Motivation { get; set; }
    public int StatusId { get; set; }
    public string ReviewerComment { get; set; }
    public DateTime ApplicationDate { get; set; }

    [Required(ErrorMessage = "Please enter name")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Please enter last name")]
    public string LastName { get; set; }

    [Required]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "ID number must be exactly 13 digits.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "ID number must contain only digits.")]
    public string Idnumber { get; set; }

    [Required(ErrorMessage = "Contact number is required.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be exactly 10 digits and contain only digits.")]
    public string ContactNumber { get; set; }
    
    [RegularExpression(@"^\\S+@\\S+\\.\\S+$", ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter university name")]
    public string UniversityName { get; set; }
}