using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Models;

public partial class YearlyUniversityAllocation
{
    public int AllocationId { get; set; }

    public int UniversityId { get; set; }

    public decimal AllocatedAmount { get; set; }

    public int BursaryDetailsId { get; set; }

    public virtual YearlyBursaryDetail BursaryDetails { get; set; } = null!;

    public virtual University University { get; set; } = null!;
}
