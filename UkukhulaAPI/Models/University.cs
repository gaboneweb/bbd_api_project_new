using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Models;

public partial class University
{
    public int UniversityId { get; set; }

    public string UniversityName { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<HeadOfDepartment> HeadOfDepartments { get; set; } = new List<HeadOfDepartment>();

    public virtual ICollection<UniversityApplication> UniversityApplications { get; set; } = new List<UniversityApplication>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<YearlyUniversityAllocation> YearlyUniversityAllocations { get; set; } = new List<YearlyUniversityAllocation>();
}
