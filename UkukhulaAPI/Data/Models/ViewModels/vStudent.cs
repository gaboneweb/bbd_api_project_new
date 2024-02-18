using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Models;

public partial class vStudent
{
    public string FirstName { get; set; }
    public string LastName{ get; set; }

    public string University{ get; set; }


    
    public string CourseOfStudy { get; set; } = null!;


}
