using System;
using System.Collections.Generic;
using UkukhulaAPI.Data.Services;

namespace UkukhulaAPI.Data.Models;

public partial class Contact
{
    // public Contact()
    // {
    //     Users = new HashSet<Users>();
    // }
    public int ContactId { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
