using System;
using System.ComponentModel.DataAnnotations;


namespace UkukhulaAPI.Data.Models.View;

public class StudentInfoVM
{

    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public string IDNumber{ get; set; }
    
    public string ContactNumber{ get; set; }
    public string Email{ get; set; }

    public string CourseOfStudy{ get; set; }
    public string Race{ get; set; }
    public string DepartmentName{ get; set; }

    public string HeadOfDepartmentFirstName{ get; set; }
    public string HeadOfDepartmentLastName{ get; set; }
    public string ApplicationMotivation{ get; set; }
    public float AverageMark{ get; set; }
    public decimal BursaryAmount{ get; set; }
    public string Status{ get; set; }
    public string ReviewComment{ get; set; }


}