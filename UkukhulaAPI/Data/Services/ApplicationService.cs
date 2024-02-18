using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

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
                                                                            .ThenInclude (app => app.User)
                                                                                .ThenInclude(app => app.Contact)
                                                                        .Include(app => app.Status)
                                                                        .ToList();
            Console.WriteLine(studentBursaryApplications[0].Status.Status);
            Console.WriteLine(studentBursaryApplications[0].Status.StatusId);
            return studentBursaryApplications.IsNullOrEmpty() ? new List<StudentBursaryApplication>() : studentBursaryApplications ;
        }


        public StudentBursaryApplication GetStudentBursaryApplicationById(int applicationId)
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
                                                                        
            Console.WriteLine(studentBursaryApplications.Status.Status);
            Console.WriteLine(studentBursaryApplications.Status.StatusId);
            return  studentBursaryApplications;
        }
    }
}
