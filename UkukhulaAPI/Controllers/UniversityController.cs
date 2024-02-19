
using Microsoft.AspNetCore.Http;
using UkukhulaAPI.Data.Models.View;
using UkukhulaAPI.Data;
using UkukhulaAPI.Controllers;

﻿using Microsoft.AspNetCore.Mvc;

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
        
        [HttpGet("list-department-bursary-status/{universityName}/{status}")]
        public IActionResult GetListBursaryAmountPerDepartmentUsingUniNameAndStatus(String universityName, String status)
        {
            var departmentBursary = _service.GetListBursaryAmountPerDepartmentUsingUniNameAndStatus(universityName, status);
            return Ok(departmentBursary);
        }
        
        [HttpGet("list-student/{universityName}")]
        public IActionResult GetListUniversityStudents(String universityName)
        {
            var listUniversityStudents = _service.GetListUniversityStudents(universityName);
            return Ok(listUniversityStudents);
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
