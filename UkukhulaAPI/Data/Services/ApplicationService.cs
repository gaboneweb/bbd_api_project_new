using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using UkukhulaAPI.Controllers.Request;

namespace UkukhulaAPI.Data.Services
{
    public class ApplicationService
    {
        private UkukhulaContext _context;
        public ApplicationService(UkukhulaContext context) {
                _context = context;
        }

        public int ChangeStatusOfStudentApplication(int applicationID,bool approve,string Comment)
        {
            StudentBursaryApplication? currentApplication = _context.StudentBursaryApplications.FirstOrDefault(application => application.ApplicationId == applicationID);
            ApplicationStatus? status = (approve) ? _context.ApplicationStatuses.FirstOrDefault(status => status.Status.Equals("Accepted"))
                                        : _context.ApplicationStatuses.FirstOrDefault(status => status.Status.Equals("Rejected"));
            if (currentApplication != null && status != null)
            {
                currentApplication.StatusId = status.StatusId ;
                currentApplication.ApplicationRejectionReason = Comment;

                return _context.SaveChanges();
                
            }
            return 0;
            
        }


        public List<StudentBursaryApplication> GetStudentBursaryApplications()
        {
            List<StudentBursaryApplication>? studentBursaryApplications = _context.StudentBursaryApplications
                                                                        .Include(app => app.Student)
                                                                            .ThenInclude(student => student.User)
                                                                                .ThenInclude(user => user.Contact)
                                                                        .Include(app => app.Student)
                                                                            .ThenInclude(student => student.Department)
                                                                        .Include(app => app.Student)
                                                                            .ThenInclude(student => student.University)
                                                                        .Include(app => app.Student)
                                                                            .ThenInclude(student => student.StudentBursaryDocument)
                                                                        .Include(app => app.Student)
                                                                            .ThenInclude(student => student.Race)
                                                                        .Include(app => app.HeadOfDepartment)
                                                                            .ThenInclude (headOfDepartment => headOfDepartment.User)
                                                                                .ThenInclude(app => app.Contact)
                                                                        .Include(user => user.Status)
                                                                        .ToList();

            return studentBursaryApplications.IsNullOrEmpty() ? new List<StudentBursaryApplication>() : studentBursaryApplications ;
        }


        public StudentBursaryApplication? GetStudentBursaryApplicationById(int applicationId)
        {
            StudentBursaryApplication? studentBursaryApplications = _context.StudentBursaryApplications
                                                                        .Include(app => app.Student)
                                                                            .ThenInclude(app => app.User)
                                                                                .ThenInclude(app => app.Contact)
                                                                        .Include(app => app.Student)
                                                                            .ThenInclude(app => app.Department)
                                                                        .Include(app => app.Student)
                                                                            .ThenInclude(app => app.University)
                                                                        .Include(app => app.Student)
                                                                            .ThenInclude(app => app.StudentBursaryDocument)
                                                                        .Include(app => app.Student)
                                                                            .ThenInclude(app => app.Race)
                                                                        .Include(app => app.HeadOfDepartment)
                                                                            .ThenInclude(app => app.User)
                                                                                .ThenInclude(app => app.Contact)
                                                                        .Include(app => app.Status)
                                                                        .FirstOrDefault(application => application.ApplicationId == applicationId);
                                                                        
     
            return  studentBursaryApplications;
        }


        public List<StudentBursaryApplication> GetApplicationForUniversityInYear(int universityID, int yearOfBursary,string status) {
            List<StudentBursaryApplication>? studentBursaryApplications = _context.StudentBursaryApplications
                                                                       .Include(application => application.Student)
                                                                           .ThenInclude(student => student.User)
                                                                               .ThenInclude(user => user.Contact)
                                                                       .Include(application => application.Student)
                                                                           .ThenInclude(student => student.Department)
                                                                       .Include(application => application.Student)
                                                                           .ThenInclude(app => app.University)
                                                                       .Include(application => application.Student)
                                                                           .ThenInclude(student => student.StudentBursaryDocument)
                                                                       .Include(application => application.Student)
                                                                           .ThenInclude(student => student.Race)
                                                                       .Include(application => application.HeadOfDepartment)
                                                                           .ThenInclude(headOfDepartment => headOfDepartment.User)
                                                                               .ThenInclude(user => user.Contact)
                                                                       .Include(application => application.Status)
                                                                       .Where(application => application.Student.UniversityId == universityID 
                                                                                      && application.BursaryDetailsId == yearOfBursary 
                                                                                      && application.Status.Status.ToLower().Equals(status.ToLower()))
                                                                       .ToList();

            return studentBursaryApplications.IsNullOrEmpty() ? new List<StudentBursaryApplication>() : studentBursaryApplications;
        }



        public bool InsertStudentApplication([FromBody] AddStudentApplicationRequest studentApplicationRequest)
        {
            var user = _context.Users.FirstOrDefault(e => e.Idnumber == studentApplicationRequest.User.Idnumber);

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
                    cx.Add(applicantionInfo);
                    cx.SaveChanges();

                }
                catch (Exception)
                {

                }
            }
            return true;

        }
        public bool updateStudentApplication(UpdateStudentApplicationRequest updateStudentApplicationRequest)
        {
            // Find the user based on the provided ID number
            var user = _context.Users.FirstOrDefault(e => e.Idnumber == updateStudentApplicationRequest.User.Idnumber);
            if (user == null)
            {
                // If the user doesn't exist, return false indicating failure
                return false;
            }

            // Find the student associated with the user
            var student = _context.Students.FirstOrDefault(e => e.UserId == user.UserId);
            if (student == null)
            {
                // If the student doesn't exist, return false indicating failure
                return false;
            }

            // Find the student bursary application associated with the student
            var studentBursaryApplication = _context.StudentBursaryApplications.FirstOrDefault(e => e.StudentId == student.StudentId);
            if (studentBursaryApplication == null || studentBursaryApplication.StatusId != 1)
            {
                // If the student bursary application doesn't exist, return false indicating failure @TODO
                return false;
            }


            studentBursaryApplication.ApplicationMotivation = updateStudentApplicationRequest.User.ApplicationMotivation;
            studentBursaryApplication.AverageMark = updateStudentApplicationRequest.User.averageMark;
            studentBursaryApplication.BursaryAmount = updateStudentApplicationRequest.User.BursaryAmount;

            _context.SaveChanges();
            return true;
        }
    }
}
