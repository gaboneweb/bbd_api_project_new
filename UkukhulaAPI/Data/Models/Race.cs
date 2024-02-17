using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Models;

public partial class Race
{
    public int RaceId { get; set; }

    public string RaceName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
