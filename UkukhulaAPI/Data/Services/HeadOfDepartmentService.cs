using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;
using UkukhulaAPI.Data.Services;
using UkukhulaAPI.Data.Services.Read;


namespace UkukhulaAPI.Data.Services
{
    public class HeadOfDepartmentService
    {
        private UkukhulaContext _context;
        public HeadOfDepartmentService(UkukhulaContext context)
        {
            _context = context;
        }

        public void AddHeadOfDepartment(HeadOfDepartmentVM headOfDepartment)
        {
            var _contact = new Contact()
            {
                ContactNumber = headOfDepartment.ContactNumber,
                Email = headOfDepartment.Email

            };
            _context.Add(_contact);
            _context.SaveChanges();

            var _user = new User()
            {
                FirstName = headOfDepartment.FirstName,
                LastName = headOfDepartment.LastName,
                Idnumber = headOfDepartment.Idnumber,
                ContactId = _contact.ContactId
            };
            _context.Add(_user);
            _context.SaveChanges();

            try
            {
                var _headOfDepartment = new HeadOfDepartment()
                {
                    // find department
                    DepartmentId = new GetDepartmentService(_context).GetDepartmentIdByDepartmentName(headOfDepartment.DepartmentName),
                    // find university
                    UniversityId = new UniversityService(_context).GetUniversityIdByUniversityName(headOfDepartment.UniversityName),
                    UserId = _user.UserId
                };
                _context.Add(_headOfDepartment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return;
            }

        }
    }
}
