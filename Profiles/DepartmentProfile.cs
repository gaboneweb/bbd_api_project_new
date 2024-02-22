using AutoMapper;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;

namespace UkukhulaAPI.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile() {
            CreateMap<Department, ViewDepartment>();
        }
    }
}
