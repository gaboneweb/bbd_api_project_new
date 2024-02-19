using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;

namespace UkukhulaAPI.Data.Services
{
    public class DepartmentService
    {
        private UkukhulaContext  _context;

        public DepartmentService(UkukhulaContext context)
        {
            _context = context;
        }



        public int GetDepartmentIdByDepartmentName(string departmentName)
        {
            try
            {
                var department = _context.Department.FirstOrDefault(n => n.DepartmentName == departmentName);
                return department.DepartmentId;
            } 
            catch (Exception ex)
            {
                return 0;
            }
        }

        public string GetDepartmentNameByDepartmentId(int departmentId)
        {
            try
            {
                var department = _context.Department.FirstOrDefault(n => n.DepartmentId == departmentId);
                return department.DepartmentName;
            } 
            catch (Exception ex)
            {
                return "";
            }
}
    }
}
