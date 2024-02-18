

using AutoMapper;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models;

namespace UkukhulaAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<User, vUser>();
        }
    }
}
