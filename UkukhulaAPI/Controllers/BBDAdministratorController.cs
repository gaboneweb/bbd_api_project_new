
using Microsoft.AspNetCore.Mvc;
using UkukhulaAPI.Data;

namespace UkukhulaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Bbdadministrator: ControllerBase
    {
        UkukhulaContext _ukukhulaContext;
        public Bbdadministrator(UkukhulaContext ukukhulaContext){
            _ukukhulaContext = ukukhulaContext;
        }
        [HttpGet]
        public IActionResult getBBDAdmin()
        {
            return Ok (_ukukhulaContext.Bbdadministrators.ToArray());
        }
    }
}