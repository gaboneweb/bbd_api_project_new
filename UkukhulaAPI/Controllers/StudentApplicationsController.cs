using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UkukhulaAPI.Controllers.Request;
using UkukhulaAPI.Data;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Services;

namespace UkukhulaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApplicationsController : ControllerBase
    {
       
        private ApplicationService applicationService;

        private readonly IMapper _mapper;

        public StudentApplicationsController(ApplicationService applicationService, IMapper mapper)
        {

            this.applicationService = applicationService;
            this._mapper = mapper;
        }

        // GET: api/Applications
        [HttpGet]
        public ActionResult<ViewStudentApplication> GetStudentBursaryApplications()
        {

            List<ViewStudentApplication> vStudents = new List<ViewStudentApplication>(); ;
            foreach (var StudentApp in applicationService.GetStudentBursaryApplications())
            {
                var studentApplication = _mapper.Map<ViewStudentApplication>(StudentApp);
                studentApplication.ApplicationStatus = new ViewApplicationStatus();
                studentApplication.ApplicationStatus.StatusId = StudentApp.StatusId;
                studentApplication.ApplicationStatus.Status = StudentApp.Status.Status;
                vStudents.Add(studentApplication);
            }

            return Ok(vStudents);
        }


        [HttpPost("application-reject-or-approval")]
        public IActionResult DecideStudentApplication([FromBody] ApplicationRequest request)
        {    

            
            if (request.ApplicationID != null && request.Approve != null && request.Comment != null)
            {
                int entriesUpdated = applicationService.ChangeStatusOfStudentApplication((int)request.ApplicationID, (bool)request.Approve, (string)request.Comment);
                if (entriesUpdated > 0)
                {
                    return Ok();
                }else if(entriesUpdated < 0)
                {
                    return BadRequest("There is not more allocation money left for student");
                }
                return BadRequest("Action was unsuccessful");

            }
            return BadRequest();

        }


        [HttpGet("{id}")]
        public IActionResult GetStudentApplicationById(int id)
        {

            ViewStudentApplication vStudents = new ViewStudentApplication(); 
            var StudentApp  = applicationService.GetStudentBursaryApplicationById(id);

            if(StudentApp != null)
            {
                vStudents = _mapper.Map<ViewStudentApplication>(StudentApp);
                vStudents.ApplicationStatus = new ViewApplicationStatus();
                vStudents.ApplicationStatus.Status = StudentApp.Status.Status;
                vStudents.ApplicationStatus.StatusId = StudentApp.StatusId;
                return Ok(vStudents);
            }
            return NotFound();
        }

        [HttpGet("{universityId}/{yearOfBursary}/{status}")]
        public ActionResult<ViewStudentApplication> GetApplicationsByStatus(int universityId,int yearOfBursary,string status)
        {
            List<ViewStudentApplication> vStudents = new List<ViewStudentApplication>(); ;
            foreach (var StudentApp in applicationService.GetApplicationForUniversityInYear(universityId,yearOfBursary,status))
            {
                var studentApplication = _mapper.Map<ViewStudentApplication>(StudentApp);
                studentApplication.ApplicationStatus = new ViewApplicationStatus();
                studentApplication.ApplicationStatus.StatusId = StudentApp.StatusId;
                studentApplication.ApplicationStatus.Status = StudentApp.Status.Status;
                vStudents.Add(studentApplication);
            }

            return Ok(vStudents);

        }


        [HttpPost]
        [Route("new/student-application")]
        public IActionResult insertStudentApplication([FromBody] AddStudentApplicationRequest addStudentApplicationRequest)
        {

            if (addStudentApplicationRequest != null)
            {
                applicationService.InsertStudentApplication(addStudentApplicationRequest);
            }

            return Ok();

        }
        [HttpPost]
        [Route("/student-application-update")]
        public IActionResult UpdateStudentApplication([FromBody] UpdateStudentApplicationRequest updateStudent)
        {

            if (updateStudent != null)
            {
                applicationService.updateStudentApplication(updateStudent);
            }

            return Ok();

        }
    }





    public class ApplicationRequest
    {

        public int? ApplicationID { get; set; }

        public bool? Approve { get; set; }


        public string? Comment { get; set; }
    }

}
