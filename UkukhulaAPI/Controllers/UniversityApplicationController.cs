
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
    
    public class UniversityApplicationController : ControllerBase
    {
        public UniversityApplicationService _universityApplicationService;

        public UniversityApplicationController(UniversityApplicationService universityApplicationService)
        {
            _universityApplicationService = universityApplicationService ;
        }

        [HttpPost("apply-university")]
        public IActionResult ApplyAsUniversity([FromBody]  UniversityApplicationVM universityApplication)
        {
            _universityApplicationService.ApplyAsUniversity(universityApplication);
            return Ok();
        }

        [HttpGet("get-application-status/{universityName}")]
        public IActionResult GetUniversityApplicationStatusByUniversityName(string universityName)
        {
            var universityStatus = _universityApplicationService.GetUniversityApplicationStatusByUniversityName(universityName);
            return Ok(universityStatus);
        }

    }
}
