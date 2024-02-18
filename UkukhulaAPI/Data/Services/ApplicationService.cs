using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;

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
            List<StudentBursaryApplication>? studentBursaryApplications = _context.StudentBursaryApplications.ToList();
            return studentBursaryApplications.IsNullOrEmpty() ? new List<StudentBursaryApplication>() : studentBursaryApplications ;
        }
    }
}
