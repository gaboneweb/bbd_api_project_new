
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

        public List<DepartmentBursaryVM> GetListBursaryAmountPerDepartmentUsingUniNameAndStatus(String universityName, String status)
        {
            var universityId = GetUniversityIdByUniversityName(universityName);
            int statusId = new ApplicationStatusService(_context).GetStatusIdByStatus(status);


            var studentsInUniversity = _context.Student.Where(n => n.UniversityId == universityId);

            IDictionary<string, decimal> departmentBursaryDict = new Dictionary<string, decimal>();

            foreach (var student in studentsInUniversity)
            {
                // limit to departments that applied this year 
                try
                {
                    var studentApplication = _context.StudentBursaryApplication.Where(n => n.StudentId == student.StudentId);

                    var currentStudentApplication = studentApplication.FirstOrDefault(n => n.BursaryDetailsId == DateTime.Now.Year);
                    
                    if (currentStudentApplication == null)
                    {
                        continue;
                    }
                    var departmentName = new DepartmentService(_context).GetDepartmentNameByDepartmentId(student.DepartmentId);

                    if (!departmentBursaryDict.ContainsKey(departmentName))
                    {
                        departmentBursaryDict.Add(departmentName, 0);
                    }



                    if (currentStudentApplication.StatusId == statusId)
                    {
                        if (departmentBursaryDict.TryGetValue(departmentName, out decimal currentBursary))
                        {
                            departmentBursaryDict[departmentName] = currentBursary + currentStudentApplication.BursaryAmount;
                        }
                        else
                        {
                            departmentBursaryDict.Add(departmentName, currentStudentApplication.BursaryAmount);
                        }


                    }
                    
                } catch (Exception ex)
                {
                    continue;
                }
            }

            List<DepartmentBursaryVM> departmentBursaryList = new List<DepartmentBursaryVM>();

            foreach (var departmentBursary in departmentBursaryDict )
            {
                var _departmentBursary = new DepartmentBursaryVM()
                {
                    DepartmentName = departmentBursary.Key,
                    Bursary = departmentBursary.Value
                };

                departmentBursaryList.Add(_departmentBursary);
            }

            return departmentBursaryList;



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
