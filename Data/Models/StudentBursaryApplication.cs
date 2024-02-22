using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Models;

public partial class StudentBursaryApplication
{
    public int ApplicationId { get; set; }

    public string ApplicationMotivation { get; set; } = null!;

    public string ApplicationRejectionReason { get; set; } = null!;

    public decimal BursaryAmount { get; set; }

    public int StudentId { get; set; }

    public int AverageMark { get; set; }

    public int BursaryDetailsId { get; set; }

    public int HeadOfDepartmentId { get; set; }

    public int StatusId { get; set; }

    public DateOnly ApplicationDate { get; set; }

    public virtual YearlyBursaryDetail BursaryDetails { get; set; } = null!;

    public virtual HeadOfDepartment HeadOfDepartment { get; set; } = null!;

    public virtual ApplicationStatus Status { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
