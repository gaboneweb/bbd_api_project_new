using System;
using System.ComponentModel.DataAnnotations;


namespace UkukhulaAPI.Data.Models.View;

public class ContactVm
{
    [Required(ErrorMessage = "Contact number is required.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be exactly 10 digits and contain only digits.")]
    public required string ContactNumber { get; set; }

    [Required(ErrorMessage = "Contact number is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public required string Email { get; set; }

}