﻿using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Models;

public partial class UniversityApplication
{
    public int UniversityApplicationId { get; set; }

    public int UniversityId { get; set; }

    public string Motivation { get; set; } = null!;

    public int StatusId { get; set; }

    public string ReviewerComment { get; set; } = null!;

    public DateTime ApplicationDate { get; set; }

    public virtual ApplicationStatus Status { get; set; } = null!;

    public virtual University University { get; set; } = null!;
}
