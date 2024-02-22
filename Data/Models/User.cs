using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Idnumber { get; set; } = null!;

    public int ContactId { get; set; }

    public virtual Bbdadministrator? Bbdadministrator { get; set; }

    public virtual Contact Contact { get; set; } = null!;

    public virtual HeadOfDepartment? HeadOfDepartment { get; set; }

    public virtual Student? Student { get; set; }

    public virtual ICollection<University> Universities { get; set; } = new List<University>();
}
