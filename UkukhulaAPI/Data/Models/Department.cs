using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<HeadOfDepartment> HeadOfDepartments { get; set; } = new List<HeadOfDepartment>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
