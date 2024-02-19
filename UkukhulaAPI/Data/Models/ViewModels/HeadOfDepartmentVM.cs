using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UkukhulaAPI.Data.Models.View;

public partial class HeadOfDepartmentVM
{
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

    [Required(ErrorMessage = "Please enter department name")]
    public string DepartmentName{ get; set; }

    [Required(ErrorMessage = "Please enter university name")]
    public string UniversityName{ get; set; }


}
