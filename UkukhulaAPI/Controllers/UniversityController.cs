
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UkukhulaAPI.Data.Services;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;
using UkukhulaAPI.Data;
using UkukhulaAPI.Controllers;


namespace UkukhulaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class UniversityController : ControllerBase
    {
        public UniversityService _universityService;

        public UniversityController(UniversityService universityService)
        {
            _universityService = universityService ;
        }

   

        [HttpGet("list-department-bursary-claimed/{universityName}")]
        public IActionResult GetListDepartmentBursaryClaimedByUniversityName(string universityName)
        {
            var departmentBursaryClaimed = _universityService.GetListDepartmentBursaryClaimedByUniversityName(universityName);
            return Ok(departmentBursaryClaimed);
        }

    }
}
