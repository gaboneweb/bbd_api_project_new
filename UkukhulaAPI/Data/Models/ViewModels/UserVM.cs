using System;


namespace UkukhulaAPI.Data.Models.View;

public class UserVm
{
     public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

      public string Idnumber { get; set; } = null!;

       public virtual Contact Contact { get; set; } = null!;
}