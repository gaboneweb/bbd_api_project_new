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

namespace UkukhulaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly UkukhulaContext _context;

        private readonly IMapper _mapper;

        public StudentsController(UkukhulaContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public ActionResult<IEnumerable<ViewStudent>> GetStudents()
        {

            List<ViewStudent>  vStudents = new List<ViewStudent>(); ;
            foreach(var vStudent in _context.Students.Include(stud => stud.StudentBursaryDocument).Include(stud => stud.University).ToList())
            {
                vStudents.Add(_mapper.Map<ViewStudent>(vStudent));
            }
            return vStudents;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public ActionResult<ViewStudent> GetStudent(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            var returnStudent = _mapper.Map<ViewStudent>(student);

            return returnStudent;
        }

 
    }
}
