using AutoMapper;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;

namespace UkukhulaAPI.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile() {
            CreateMap<Student, vStudent>();
        }
    }
}
