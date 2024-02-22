using AutoMapper;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;

namespace UkukhulaAPI.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile() {
            CreateMap<Student, ViewStudent>()
                .ForMember(dest => dest.Univeristy, src => src.MapFrom(app => app.University))
                .ForMember(dest => dest.Documents, src => src.MapFrom(app => app.StudentBursaryDocument));
        }
    }
}
