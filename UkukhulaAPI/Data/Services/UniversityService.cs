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
