using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Models;

public partial class StudentBursaryDocument
{
    public int StudentDocumentId { get; set; }

    public string IdCopy { get; set; } = null!;

    public string Transcript { get; set; } = null!;

    public string CurriculumVitae { get; set; } = null!;

    public int StudentId { get; set; }

    public virtual Student Student { get; set; } = null!;
}
