using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;
using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Services.Read
{
    public class GetHeadOfDepartmentService
    {
        private UkukhulaContext  _context;

        public GetHeadOfDepartmentService(UkukhulaContext context)
        {
            _context = context;
        }




        public int GetDepartmentIdByHeadOfDepartmentId(int headOfDepartmentId)
        {
            try
            {
                var headOfDepartment = _context.HeadOfDepartment.FirstOrDefault(n => n.HeadOfDepartmentId == headOfDepartmentId);
                return headOfDepartment.DepartmentId;
            } 
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetUniversityIdByHeadOfDepartmentId(int headOfDepartmentId)
        {
            try
            {
                var headOfDepartment = _context.HeadOfDepartment.FirstOrDefault(n => n.HeadOfDepartmentId == headOfDepartmentId);
                return headOfDepartment.UniversityId;
            } 
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetUserIdByHeadOfDepartmentId(int headOfDepartmentId)
        {
            try
            {
                var headOfDepartment = _context.HeadOfDepartment.FirstOrDefault(n => n.HeadOfDepartmentId == headOfDepartmentId);
                return headOfDepartment.UserId;
            } 
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<HeadOfDepartment> GetAllHeadOfDepartments()
        {

            return _context.HeadOfDepartment.ToList();

        }

    }
}
