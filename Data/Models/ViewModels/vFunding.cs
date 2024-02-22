
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace UkukhulaAPI.Data.Models.ViewModels
{
    public class vFunding
    {
     [Required]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "ID number must be exactly 13 digits.")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "ID number must contain only digits.")]
    public string Idnumber { get; set; } = null!;
     [Required]
    public decimal YearBudget { get; set; }
     [Required]
    public decimal CapAmountPerStudent { get; set; }
    }
}
