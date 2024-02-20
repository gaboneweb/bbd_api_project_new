

using Microsoft.AspNetCore.Identity;

namespace UkukhulaAPI.Data.Models;

public class AppUser : IdentityUser
{
         public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? ShowFullName { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime? ProfilePictureUpdated { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public DateTime? PasswordLastChanged { get; set; }
        public bool? IsActive { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
}