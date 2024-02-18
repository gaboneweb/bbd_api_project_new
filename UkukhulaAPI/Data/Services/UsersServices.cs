
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.View;

namespace UkukhulaAPI.Data.Services;

public class UsersService : IDisposable
{
    private readonly UkukhulaContext _context;
    public UsersService(UkukhulaContext context)
    {
        _context = context;
    }

    public bool AddUser(UserRegistrationVm user, ContactVm contact)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {

                var _newContact = new Contact()
                {
                    ContactNumber = contact.ContactNumber,
                    Email = contact.Email

                };
                _context.Add(_newContact);
                _context.SaveChanges();

                var _newUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Idnumber = user.Idnumber,
                    ContactId = _newContact.ContactId
                };
                _context.Add(_newUser);
                int state = _context.SaveChanges();
                transaction.Commit();
                return state > 0;
            }
            catch (Exception)
            {
                transaction.Rollback();

                return false;

            }

        }

    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public LoginVm findUser(string username)
    {
        using (var dbContext = _context)
        {

            var entity = dbContext.Users.FirstOrDefault(e => e.Idnumber == username);

            if (entity != null)
            {
                return new LoginVm() { Username = entity.Idnumber, Password = "" };
            }
            else
            {
                return null;
            }

        }

        //  public class LoginRequest
        // {
        //     public string Username { get; set; }
        //     public string Password { get; set; }
        // }
        //  public class ApplicationUser: IdentityUser
        // {
        // }
        //  public static class UserRoles
        // {
        //     public const string Admin = "Admin";
        //     public const string User = "User";
        // }

    }
}