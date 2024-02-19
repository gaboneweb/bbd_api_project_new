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
                                            .Include(stud => stud.User)
                                                .ThenInclude(stud => stud.Contact)
                                            .Include(stud => stud.Race)
                                            .Include(stud => stud.Department)
                                            .Include(stud => stud.StudentBursaryDocument)
                                            .Include(stud => stud.University)
                                            .ToList();
     
            return students;
        }


        public Student? GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }


    }
}
