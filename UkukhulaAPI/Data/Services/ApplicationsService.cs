using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using UkukhulaAPI.Data;
using System.Linq;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.View;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace UkukhulaAPI.Data.Services;

public class ApplicationsService
{
    private readonly UkukhulaContext _context;
    public ApplicationsService(UkukhulaContext context)
    {
        _context = context;
    }

    public string GetApplications()
    {
        List<ApplicationVm> applicationVms = _context.StudentBursaryApplications
            .Include(app => app.Student)
                .ThenInclude(student => student.User) // Include the User entity associated with the Student
            .Include(app => app.BursaryDetails)
            .Include(app => app.Status)
            .Include(app => app.HeadOfDepartment)
            // .Include(app => app.Student.University) // Include the University entity associated with the Student
            .Select(app => new ApplicationVm
            {
                ApplicationMotivation = app.ApplicationMotivation,
                ApplicationRejectionReason = app.ApplicationRejectionReason,
                BursaryAmount = app.BursaryAmount,
                AverageMark = app.AverageMark,
                ApplicationDate = app.ApplicationDate,
                StudentFirstName = app.Student.User.FirstName, // Access FirstName through User navigation property
                StudentLastName = app.Student.User.LastName, // Access LastName through User navigation property
                StudentUniversity = app.Student.University.UniversityName, // Access UniversityName through University navigation property
                CourseOfStudy = app.Student.CourseOfStudy,
                // YearBudget = app.BursaryDetails.YearBudget,
                // CapAmountPerStudent = app.BursaryDetails.CapAmountPerStudent,
                race=app.Student.Race.RaceName,
                Status = app.Status.Status,
                Department = app.HeadOfDepartment.Department.DepartmentName,
                HeadOfDepartmentUniversity = app.HeadOfDepartment.University.UniversityName,
                HeadOfDepartmentFirstName = app.HeadOfDepartment.User.FirstName,
                HeadOfDepartmentLastName = app.HeadOfDepartment.User.LastName
            })
            .ToList();

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        return JsonSerializer.Serialize(applicationVms, options);
    }

    public class AddUserRequest
    {
        public required UserRegistrationVm User { get; set; }
        public required ContactVm Contact { get; set; }
    }
    // public bool findApplication(UserRegistrationVm user, ContactVm contact)
    // {


    // }

    // public void Dispose()
    // {
    //     _context.Dispose();
    //     // throw new NotImplementedException();
    // }
}





