using Microsoft.AspNetCore.Mvc;

using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Services;

namespace UkukhulaAPI.Controllers
{
    public class UniversityController : Controller
    {   

        private readonly UniversityService _service;

        public UniversityController(UniversityService service)
        {
            _service = service;
        }



        [HttpGet("{universityId}")]
        public ActionResult<ViewYearlyUniversityAllocation> GetMoneySpendForUniversityInEachYear( int universityId)
        {

            List<ViewYearlyUniversityAllocation> universityAllocations = new List<ViewYearlyUniversityAllocation>();

            foreach(var allocation in _service.GetUniversityAllocation(universityId))
            {
                var yearlyAllocation = new ViewYearlyUniversityAllocation();

                yearlyAllocation.AllocationId = allocation.AllocationId;

                yearlyAllocation.AllocatedAmount = allocation.AllocatedAmount;

                yearlyAllocation.TotalAmountsSpent = _service.GetMoneySpentForAUniversity(universityId, allocation.BursaryDetailsId);

                yearlyAllocation.Year = allocation.BursaryDetailsId;

                yearlyAllocation.University = new ViewUniversity();

                yearlyAllocation.University.UniversityId = allocation.University.UniversityId;

                yearlyAllocation.University.UniversityName = allocation.University.UniversityName;

                universityAllocations.Add(yearlyAllocation);    


            }


            return Ok(universityAllocations);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
