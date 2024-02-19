using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;
using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Services.Read
{
    public class GetStudentBursaryApplicationService
    {
        private UkukhulaContext  _context;

        public GetStudentBursaryApplicationService(UkukhulaContext context)
        {
            _context = context;
        }


        public string GetApplicationMotivationByApplicationId(int applicationId)
        {
            try
            {
                var studentBursaryApplication = _context.StudentBursaryApplication.FirstOrDefault(n => n.ApplicationId == applicationId);
                return studentBursaryApplication.ApplicationMotivation;
            } 
            catch (Exception ex)
            {
                return "";
            }
        }

        public string GetApplicationRejectionReasonByApplicationId(int applicationId)
        {
            try
            {
                var studentBursaryApplication = _context.StudentBursaryApplication.FirstOrDefault(n => n.ApplicationId == applicationId);
                return studentBursaryApplication.ApplicationRejectionReason;
            } 
            catch (Exception ex)
            {
                return "";
            }
        }

        public decimal GetBursaryAmountByApplicationId(int applicationId)
        {
            try
            {
                var studentBursaryApplication = _context.StudentBursaryApplication.FirstOrDefault(n => n.ApplicationId == applicationId);
                return studentBursaryApplication.BursaryAmount;
            } 
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetStudentIdByApplicationId(int applicationId)
        {
            try
            {
                var studentBursaryApplication = _context.StudentBursaryApplication.FirstOrDefault(n => n.ApplicationId == applicationId);
                return studentBursaryApplication.StudentId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetAverageMarkByApplicationId(int applicationId)
        {
            try
            {
                var studentBursaryApplication = _context.StudentBursaryApplication.FirstOrDefault(n => n.ApplicationId == applicationId);
                return studentBursaryApplication.AverageMark;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetBursaryDetailsIdByApplicationId(int applicationId)
        {
            try
            {
                var studentBursaryApplication = _context.StudentBursaryApplication.FirstOrDefault(n => n.ApplicationId == applicationId);
                return studentBursaryApplication.BursaryDetailsId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetHeadOfDepartmentIdByApplicationId(int applicationId)
        {
            try
            {
                var studentBursaryApplication = _context.StudentBursaryApplication.FirstOrDefault(n => n.ApplicationId == applicationId);
                return studentBursaryApplication.HeadOfDepartmentId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetStatusIdByApplicationId(int applicationId)
        {
            try
            {
                var studentBursaryApplication = _context.StudentBursaryApplication.FirstOrDefault(n => n.ApplicationId == applicationId);
                return studentBursaryApplication.StatusId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DateOnly GetApplicationDateByApplicationId(int applicationId)
        {
            try
            {
                var studentBursaryApplication = _context.StudentBursaryApplication.FirstOrDefault(n => n.ApplicationId == applicationId);
                return studentBursaryApplication.ApplicationDate;
            }
            catch (Exception ex)
            {
                return DateOnly.FromDateTime(DateTime.Now);
            }
        }

        public int GetApplicationIdByStudentId(int studentId)
        {
            try
            {
                var studentBursaryApplication = _context.StudentBursaryApplication.Where(n => n.StudentId == studentId);
                var currentStudentBursaryApplication = studentBursaryApplication.FirstOrDefault(n => n.BursaryDetailsId == DateTime.Now.Year);


                return currentStudentBursaryApplication.ApplicationId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public List<StudentBursaryApplication> GetAllStudentBursaryApplication()
        {

            return _context.StudentBursaryApplication.ToList();

        }
    }
}
