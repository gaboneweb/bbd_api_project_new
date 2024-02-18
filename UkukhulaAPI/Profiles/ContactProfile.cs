using AutoMapper;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;

namespace UkukhulaAPI.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile() {
            CreateMap<Contact, vContact>();      
        }
    }
}
