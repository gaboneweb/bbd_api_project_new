using System;
using System.ComponentModel.DataAnnotations;


namespace UkukhulaAPI.Data.Models.View;

public class UserRegistrationVm
{
    [Required(ErrorMessage = "Please enter name")]
    public string FirstName { get; set; } = null!;
    [Required(ErrorMessage = "Please enter last name")]

    public string LastName { get; set; } = null!;

    [Required]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "ID number must be exactly 13 digits.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "ID number must contain only digits.")]
    public string Idnumber { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }= null!;

}