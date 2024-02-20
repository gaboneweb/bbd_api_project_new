
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Services;

namespace UkukhulaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService studentService;

        private readonly IMapper _mapper;

        public StudentsController(StudentService studentService,IMapper mapper)
        {
            this.studentService = studentService;
            _mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public ActionResult<IEnumerable<ViewStudent>> GetStudents()
        {

            List<ViewStudent>  vStudents = new List<ViewStudent>(); ;
            foreach(var vStudent in studentService.GetStudents())
            {
                vStudents.Add(_mapper.Map<ViewStudent>(vStudent));
            }
            return vStudents;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public ActionResult<ViewStudent> GetStudent(int id)
        {
            var student = studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            var returnStudent = _mapper.Map<ViewStudent>(student);

            return returnStudent;
        }

 
    }
}
