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
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using UkukhulaAPI.Controllers.Request;
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
                race = app.Student.Race.RaceName,
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

    public bool InsertStudentApplication([FromBody] AddStudentApplicationRequest studentApplicationRequest)
    {
        var user = _context.Users.FirstOrDefault(e => e.Idnumber == studentApplicationRequest.User.Idnumber);
        // var user = _context.Users.Find(BigInteger.Parse(studentApplicationRequest.User.Idnumber));
        if (user != null)
        {
            return false;
        }
        using (var cx = _context)
        {
            DateTime today = DateTime.Today;

            try
            {
                var applicantContact = new Contact()
                {
                    Email = studentApplicationRequest.Contact.Email,
                    ContactNumber = studentApplicationRequest.Contact.ContactNumber
                };
                cx.Add(applicantContact);
                cx.SaveChanges();

                var applicantInfo = new User()
                {
                    FirstName = studentApplicationRequest.User.FirstName,
                    LastName = studentApplicationRequest.User.LastName,
                    Idnumber = studentApplicationRequest.User.Idnumber,
                    ContactId = applicantContact.ContactId
                };
                cx.Add(applicantInfo);
                cx.SaveChanges();


                var hod = new HeadOfDepartment()
                {
                    HeadOfDepartmentId = studentApplicationRequest.User.HODId
                };

                var _newUser = cx.Users.FirstOrDefault(e => e.Idnumber == studentApplicationRequest.User.Idnumber);
                var _hod = cx.HeadOfDepartments.FirstOrDefault(e => e.HeadOfDepartmentId == studentApplicationRequest.User.HODId);
                if (_newUser == null || _hod == null)
                {
                    return false;
                }

                var asStudent = new Student()
                {
                    CourseOfStudy = studentApplicationRequest.User.CourseOfStudy,
                    UniversityId = _hod.UniversityId,
                    RaceId = studentApplicationRequest.User.race,
                    UserId = _newUser.UserId,
                    DepartmentId = _hod.DepartmentId


                };
                cx.Add(asStudent);
                cx.SaveChanges();

                var _newstudent = cx.Students.FirstOrDefault(e => e.User.Idnumber == studentApplicationRequest.User.Idnumber);

                if (_newstudent == null)
                {
                    return false;
                }

                var applicantionInfo = new StudentBursaryApplication()
                {
                    StudentId = _newstudent.StudentId,
                    HeadOfDepartmentId = _hod.HeadOfDepartmentId,
                    ApplicationDate = DateOnly.FromDateTime(today),
                    ApplicationMotivation = studentApplicationRequest.User.ApplicationMotivation,
                    AverageMark = studentApplicationRequest.User.averageMark,
                    ApplicationRejectionReason = "N/A",
                    BursaryAmount = studentApplicationRequest.User.BursaryAmount,
                    StatusId = 1,
                    BursaryDetailsId = DateTime.Now.Year,


                };
                // cx.Add(hod);
                // cx.SaveChanges();


                cx.Add(applicantionInfo);
                cx.SaveChanges();






            }
            catch (Exception)
            {

            }
        }
        return true;

    }

    // public class AddStudentApplicationRequest
    // {
    //     public required StudentRegistrationVm User { get; set; }
    //     public required ContactVm Contact { get; set; }
    // }
    // public bool findApplication(UserRegistrationVm user, ContactVm contact)
    // {


    // }

    // public void Dispose()
    // {
    //     _context.Dispose();
    //     // throw new NotImplementedException();
    // }
}





