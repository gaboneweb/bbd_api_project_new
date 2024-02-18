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
        public ActionResult<IEnumerable<vStudent>> GetStudents()
        {

            List<vStudent>  vStudents = new List<vStudent>(); ;
            foreach(var vStudent in _context.Students.ToList())
            {
                vStudents.Add(_mapper.Map<vStudent>(vStudent));
            }
            return vStudents;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public ActionResult<vStudent> GetStudent(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            var returnStudent = _mapper.Map<vStudent>(student);

            return returnStudent;
        }

 
    }
}
