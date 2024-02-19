using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public int UserId { get; set; }

    public int RaceId { get; set; }

    public string CourseOfStudy { get; set; } = null!;

    public int UniversityId { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;

    public virtual StudentBursaryApplication? StudentBursaryApplication { get; set; }

    public virtual StudentBursaryDocument? StudentBursaryDocument { get; set; }


    //public virtual University University { get; set; } = null!;

    //  public virtual University? University { get; set; }


    public virtual User User { get; set; } = null!;
}
