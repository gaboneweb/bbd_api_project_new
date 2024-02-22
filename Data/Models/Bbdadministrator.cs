using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Models;

public partial class Bbdadministrator
{
    public int AdministratorId { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
