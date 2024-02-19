using Microsoft.EntityFrameworkCore;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;

namespace UkukhulaAPI.Data.Services
{
    public class StudentService
    {
        private readonly UkukhulaContext _context;
        public StudentService(UkukhulaContext context) {
            _context = context;
        }



        public List<Student> GetStudents()
        {

            List<Student> students = _context.Students
                                            .Include(student  => student.User)
                                                .ThenInclude(user => user.Contact)
                                            .Include(student => student.Race)
                                            .Include(student => student.Department)
                                            .Include(student => student.StudentBursaryDocument)
                                            .Include(student => student.University)
                                            .ToList();
     
            return students;
        }


        public Student? GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }


    }
}
