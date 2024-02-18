using UkukhulaAPI.Data.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using UkukhulaAPI.Data.Services;
using UkukhulaAPI.Data;
using Microsoft.AspNetCore.Mvc;
using UkukhulaAPI.Controllers.Request;


namespace UkukhulaAPI;
  [Route("api/[controller]")]
    [ApiController]
public class StudentApplicationController: ControllerBase
{

    private readonly ApplicationsService _service;

    
   
    public StudentApplicationController(ApplicationsService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("HOD/student-application")]
    public IActionResult insertStudentApplication([FromBody]AddStudentApplicationRequest addStudentApplicationRequest)
    {

        if(addStudentApplicationRequest!=null)
        {
            _service.InsertStudentApplication(addStudentApplicationRequest);
        }

        return Ok();

    }

}