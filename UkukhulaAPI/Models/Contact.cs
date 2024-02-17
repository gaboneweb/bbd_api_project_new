using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
