using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        private readonly IMapper _mapper;

        public ApplicationsController(ApplicationService applicationService,IMapper mapper)
        {

            this.applicationService = applicationService;
            this._mapper = mapper;
        }

        // GET: api/Applications
        [HttpGet]
        public ActionResult<vStudentApplication> GetStudentBursaryApplications()
        {

            List<vStudentApplication> vStudents = new List<vStudentApplication>(); ;
            foreach (var StudentApp in applicationService.GetStudentBursaryApplications())
            {
                vStudents.Add(_mapper.Map<vStudentApplication>(StudentApp));
            }
            return Ok(vStudents);
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
