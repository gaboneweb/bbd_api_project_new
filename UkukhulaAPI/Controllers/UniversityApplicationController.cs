
using Microsoft.AspNetCore.Mvc;
using UkukhulaAPI.Data;

namespace UkukhulaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UniversityApplicationController: ControllerBase
    {
        UkukhulaContext _ukukhulaContext;
        public UniversityApplicationController(UkukhulaContext ukukhulaContext){
            _ukukhulaContext = ukukhulaContext;
        }
        [HttpGet]
        public IActionResult GetUniversityApplications()
        {
            return Ok (_ukukhulaContext.UniversityApplications.ToArray());
        }
    }
}