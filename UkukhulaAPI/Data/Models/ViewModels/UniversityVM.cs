using System.ComponentModel.DataAnnotations;



namespace UkukhulaAPI.Data.Models.View;

public class UniversityVM
{

    [Required(ErrorMessage = "Please enter university name")]
    public string UniversityName { get; set; }


}