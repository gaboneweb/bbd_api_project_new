using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Models;

public partial class YearlyBursaryDetail
{
    public int BursaryDetailsId { get; set; }

    public decimal YearBudget { get; set; }

    public decimal CapAmountPerStudent { get; set; }

    public virtual ICollection<StudentBursaryApplication> StudentBursaryApplications { get; set; } = new List<StudentBursaryApplication>();

    public virtual ICollection<YearlyUniversityAllocation> YearlyUniversityAllocations { get; set; } = new List<YearlyUniversityAllocation>();
}
