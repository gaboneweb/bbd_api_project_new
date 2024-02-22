using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;
using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Services.Read
{
    public class GetStudentService
    {
        private UkukhulaContext  _context;

        public GetStudentService(UkukhulaContext context)
        {
            _context = context;
        }




        public int GetUserIdByStudentId(int studentId)
        {
            try
            {
                var student = _context.Student.FirstOrDefault(n => n.StudentId == studentId);
                return student.UserId;
            } 
            catch (Exception ex)
            {
                return 0;
            }
        }
        
        public int GetRaceIdByStudentId(int studentId)
        {
            try
            {
                var student = _context.Student.FirstOrDefault(n => n.StudentId == studentId);
                return student.RaceId;
            } 
            catch (Exception ex)
            {
                return 0;
            }
        }

        public string GetCourseOfStudyByStudentId(int studentId)
        {
            try
            {
                var student = _context.Student.FirstOrDefault(n => n.StudentId == studentId);
                return student.CourseOfStudy;
            } 
            catch (Exception ex)
            {
                return "";
            }
        }

        public int GetUniversityIdByStudentId(int studentId)
        {
            try
            {
                var student = _context.Student.FirstOrDefault(n => n.StudentId == studentId);
                return student.UniversityId;
            } 
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetDepartmentIdByStudentId(int StudentId)
        {
            try
            {
                var student = _context.Student.FirstOrDefault(n => n.StudentId == StudentId);
                return student.DepartmentId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

       
    }
}
