using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UkukhulaAPI.Data;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Services;

namespace UkukhulaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        /*private readonly UkukhulaContext _context;*/
        private ApplicationService applicationService;

        public ApplicationsController(ApplicationService applicationService)
        {

            this.applicationService = applicationService;
        }

        // GET: api/Applications
        [HttpGet]
        public ActionResult<vStudentAppliation> GetStudentBursaryApplications()
        {
            
            return Ok(applicationService.GetStudentBursaryApplications());
        }


        [HttpPost]
        public IActionResult DecideStudentApplication([FromBody] ApplicationRequest request)
        {
            if(request.ApplicationID != null &&  request.Approve!= null && request.Comment != null)
            {
                int entriesUpdated = applicationService.ChangeStatusOfStudentApplication((int)request.ApplicationID, (bool)request.Approve, (string)request.Comment);
                if (entriesUpdated > 0)
                {
                    return Ok();
                }
                return BadRequest();

            }
            else if(request.Comment == null)
            {

            }
            return BadRequest();
           
        }
    }


    public class ApplicationRequest
    {

        public int? ApplicationID { get; set; }

        public bool? Approve { get; set; }


        public string? Comment { get; set; }
    }

}
