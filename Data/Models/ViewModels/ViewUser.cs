namespace UkukhulaAPI.Data.Models.ViewModels
{
    public class ViewUser
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Idnumber { get; set; } = null!;

        public ViewContact Contact { get; set; }
    }
}
