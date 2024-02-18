using AutoMapper;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;

namespace UkukhulaAPI.Profiles
{
    public class HeadOfDepartmentProfile : Profile
    {
        public HeadOfDepartmentProfile() {
            CreateMap<HeadOfDepartment, ViewHeadOfDepartment>();
        }    
    }
}
