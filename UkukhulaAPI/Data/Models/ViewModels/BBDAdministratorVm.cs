

using System.ComponentModel.DataAnnotations;
using UkukhulaAPI.Data.Models.View;

public class  BbdadministratorVm {


     [Required(ErrorMessage = "Please enter name")]
    public string FirstName { get; set; } = null!;
    [Required(ErrorMessage = "Please enter last name")]

    public string LastName { get; set; } = null!;

    [Required]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "ID number must be exactly 13 digits.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "ID number must contain only digits.")]
    public string Idnumber { get; set; } = null!;

    public ContactVm contact {get;set;}
}