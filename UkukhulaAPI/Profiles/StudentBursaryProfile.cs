using AutoMapper;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;

namespace UkukhulaAPI.Profiles
{
    public class StudentBursaryProfile: Profile
    {
        public StudentBursaryProfile() {
            CreateMap<StudentBursaryApplication, vStudentApplication>();
        }
    }
}
