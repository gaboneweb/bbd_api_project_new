
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;
using System.Collections.Generic;
using System;

using Microsoft.EntityFrameworkCore;
using UkukhulaAPI.Data.Models;


namespace UkukhulaAPI.Data.Services
{
    public class UniversityService
    {

        private readonly UkukhulaContext _context;



        public UniversityService(UkukhulaContext context)
        {
            _context = context;

        }



        public int GetUniversityIdByUniversityName(string universityName)
        {
            var university = _context.University.FirstOrDefault(n => n.UniversityName == universityName);
            return university.UniversityId;
        }

        public List<DepartmentBursaryClaimedVM> GetListDepartmentBursaryClaimedByUniversityName(String universityName)
        {
            var universityId = GetUniversityIdByUniversityName(universityName);


            var studentsInUniversity = _context.Student.Where(n => n.UniversityId == universityId);

            IDictionary<string, decimal> departmentBursaryClaimedDict = new Dictionary<string, decimal>();

            foreach (var student in studentsInUniversity)
            {
                var departmentName = new DepartmentService(_context).GetDepartmentNameByDepartmentId(student.DepartmentId);
                var studentApplication = _context.StudentBursaryApplication.FirstOrDefault(n => n.StudentId == student.StudentId);

                if (studentApplication != null ) 
                {
                    if (studentApplication.StatusId == 2)
                    {


                        if (departmentBursaryClaimedDict.ContainsKey(departmentName))
                        {
                            var currentAmount = departmentBursaryClaimedDict[departmentName];
                            departmentBursaryClaimedDict[departmentName] = currentAmount + studentApplication.BursaryAmount;
                        } else
                        {
                            departmentBursaryClaimedDict[departmentName] = studentApplication.BursaryAmount;
                        }
                    } else
                    {
                        departmentBursaryClaimedDict[departmentName] = studentApplication.BursaryAmount;
                    }
                }
            }

            List<DepartmentBursaryClaimedVM> departmentBursaryClaimed = new List<DepartmentBursaryClaimedVM>();

            foreach (var departmentBursary in departmentBursaryClaimedDict )
            {
                var _departmentBursaryClaimed = new DepartmentBursaryClaimedVM()
                {
                    DepartmentName = departmentBursary.Key,
                    BursaryClaimed = departmentBursary.Value
                };

                departmentBursaryClaimed.Add(_departmentBursaryClaimed);
            }

            return departmentBursaryClaimed;



        }


        public List<YearlyUniversityAllocation> GetUniversityAllocation(int univerityId)
        {
            List<YearlyUniversityAllocation> yearlyUniversityAllocations = _context.YearlyUniversityAllocations.Include(allocation => allocation.University)
                                                                                                                .Where(allocation => allocation.UniversityId == univerityId).ToList();

            return yearlyUniversityAllocations;
        }

        public decimal GetMoneySpentForAUniversity(int univeristyId,int year)
        {
            ApplicationService service = new ApplicationService(_context);

            List<StudentBursaryApplication> applications = service.GetApplicationForUniversityInYear(univeristyId, year, "Accepted");

            decimal sum = 0;

            foreach(var  application in applications) {
                sum += application.BursaryAmount;
            }


            return sum;

        }
    }
}
