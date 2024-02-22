using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;
using System;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Services.Read
{
    public class GetUserService
    {
        private UkukhulaContext  _context;

        public GetUserService(UkukhulaContext context)
        {
            _context = context;
        }


        public string GetFirstNameByUserId(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(n => n.UserId == userId);
                return user.FirstName;
            } 
            catch (Exception ex)
            {
                return "";
            }
        }


        public string GetLastNameByUserId(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(n => n.UserId == userId);
                return user.LastName;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string GetIdNumberByUserId(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(n => n.UserId == userId);
                return user.Idnumber;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public int GetContactIdByUserId(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(n => n.UserId == userId);
                return user.ContactId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetUserIdByIdNumber(string idNumber)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(n => n.Idnumber == idNumber);
                return user.UserId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<User> GetAllUsers()
        {

            return _context.Users.ToList();

        }
    }
}
