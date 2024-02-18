using System.ComponentModel.DataAnnotations;

namespace UkukhulaAPI.Data.Models.View;

 public class LoginVm
    {
    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }= null!;

        public string Role { get; set; }
    }