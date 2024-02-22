
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
    
    public class HeadOfDepartmentController : ControllerBase
    {
        public HeadOfDepartmentService _headOfDepartmentService;

        public HeadOfDepartmentController(HeadOfDepartmentService headOfDepartmentService)
        {
            _headOfDepartmentService = headOfDepartmentService ;
        }

        [HttpPost("add-HeadOfDepartment")]
        public IActionResult AddHeadOfDepartment([FromBody]  HeadOfDepartmentVM headOfDepartment)
        {
            _headOfDepartmentService.AddHeadOfDepartment(headOfDepartment);
            return Ok();
        }

    }
}
