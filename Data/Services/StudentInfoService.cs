using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;
using UkukhulaAPI.Data.Services;
using System;
using System.Collections;
using UkukhulaAPI.Data.Services.Read;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Services
{
    public class StudentInfoService
    {
        private UkukhulaContext _context;
        public StudentInfoService(UkukhulaContext context)
        {
            _context = context;
        }

        public Dictionary<string,string> GetStudentInfo(int studentId)
        {
            Dictionary<string, string> _studentInfo = new Dictionary<string, string>();

            try
            {
                GetStudentService getStudentService = new GetStudentService(_context);

                int userId = getStudentService.GetUserIdByStudentId(studentId);
                GetUserService getUserService = new GetUserService(_context);
                _studentInfo.Add("FirstName", getUserService.GetFirstNameByUserId(userId));
                _studentInfo.Add("LastName", getUserService.GetLastNameByUserId(userId));
                _studentInfo.Add("IDNumber", getUserService.GetIdNumberByUserId(userId));

                int contactId = getUserService.GetContactIdByUserId(userId);
                GetContactService getContactService = new GetContactService(_context);
                _studentInfo.Add("ContactNumber", getContactService.GetContactNumberByContactId(contactId));
                _studentInfo.Add("Email", getContactService.GetEmailByContactId(contactId));


                int raceId = getStudentService.GetRaceIdByStudentId(studentId);
                GetRaceService getRaceService = new GetRaceService(_context);
                _studentInfo.Add("Race", getRaceService.GetRaceNameByRaceId(raceId));


                _studentInfo.Add("CourseOfStudy", getStudentService.GetCourseOfStudyByStudentId(studentId));

                int universityId = getStudentService.GetUniversityIdByStudentId(studentId);
                GetUniversityService getUniversityService = new GetUniversityService(_context);
                _studentInfo.Add("UniversityName", getUniversityService.GetUniversityNameByUniversityId(universityId));

                int departmentId = getStudentService.GetDepartmentIdByStudentId(studentId);
                GetDepartmentService getDepartmentService = new GetDepartmentService(_context);
                _studentInfo.Add("DepartmentName", getDepartmentService.GetDepartmentNameByDepartmentId(departmentId));

                GetStudentBursaryApplicationService getStudentBursaryApplicationService = new GetStudentBursaryApplicationService(_context);
                int applicationId = getStudentBursaryApplicationService.GetApplicationIdByStudentId(studentId);
                _studentInfo.Add("ApplicationMotivation", getStudentBursaryApplicationService.GetApplicationMotivationByApplicationId(applicationId));
                _studentInfo.Add("ApplicationRejectionReason", getStudentBursaryApplicationService.GetApplicationRejectionReasonByApplicationId(applicationId));
                _studentInfo.Add("BursaryAmount", getStudentBursaryApplicationService.GetBursaryAmountByApplicationId(applicationId).ToString());
                _studentInfo.Add("AverageMark", getStudentBursaryApplicationService.GetAverageMarkByApplicationId(applicationId).ToString());
                _studentInfo.Add("BursaryDetailsID", getStudentBursaryApplicationService.GetBursaryDetailsIdByApplicationId(applicationId).ToString());
                
                int headOfDepartmentId = getStudentBursaryApplicationService.GetHeadOfDepartmentIdByApplicationId(studentId);
                GetHeadOfDepartmentService getHeadOfDepartmentService = new GetHeadOfDepartmentService(_context);


                int statusId = getStudentBursaryApplicationService.GetStatusIdByApplicationId(studentId);
                GetApplicationStatusService getApplicationStatusService = new GetApplicationStatusService(_context);
                _studentInfo.Add("Status", getApplicationStatusService.GetStatusByStatusId(statusId).ToString());


                _studentInfo.Add("ApplicationDate", getStudentBursaryApplicationService.GetApplicationDateByApplicationId(applicationId).ToString());


                return _studentInfo;
                //public string HeadOfDepartmentFirstName { get; set; }
                //public string HeadOfDepartmentLastName { get; set; }

            } catch (Exception ex)
            {
                return null;
            }








        }
    }
}
