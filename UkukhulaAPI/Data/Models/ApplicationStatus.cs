using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Models;

public partial class ApplicationStatus
{
    public int StatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<StudentBursaryApplication> StudentBursaryApplications { get; set; } = new List<StudentBursaryApplication>();

    public virtual ICollection<UniversityApplication> UniversityApplications { get; set; } = new List<UniversityApplication>();
}
