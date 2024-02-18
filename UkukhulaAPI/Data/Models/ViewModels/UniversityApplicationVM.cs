using System;
using System.ComponentModel.DataAnnotations;


namespace UkukhulaAPI.Data.Models.View;

public class UniversityApplicationVM
{
    public string Motivation { get; set; }
    public int StatusId { get; set; }
    public string ReviewerComment { get; set; }
    public DateTime ApplicationDate { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Idnumber { get; set; }

    public string ContactNumber { get; set; }
    public string Email { get; set; }

    public string UniversityName { get; set; }
}