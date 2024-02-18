using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Models.View;

public partial class HeadOfDepartmentVM
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Idnumber { get; set; }

    public string ContactNumber { get; set; }
    public string Email { get; set; }

    public string DepartmentName{ get; set; }

    public string UniversityName{ get; set; }


}
