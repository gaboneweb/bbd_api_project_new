using AutoMapper;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;

namespace UkukhulaAPI.Profiles
{
    public class RaceProfile : Profile
    {
        public RaceProfile() {
            CreateMap<Race, ViewRace>();
        }
    }
}
