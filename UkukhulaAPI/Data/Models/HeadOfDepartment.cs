using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Models;

public partial class HeadOfDepartment
{
    public int HeadOfDepartmentId { get; set; }

    public int DepartmentId { get; set; }

    public int UniversityId { get; set; }

    public int UserId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<StudentBursaryApplication> StudentBursaryApplications { get; set; } = new List<StudentBursaryApplication>();

    public virtual University University { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
