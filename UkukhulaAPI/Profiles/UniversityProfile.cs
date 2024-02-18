using AutoMapper;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;

namespace UkukhulaAPI.Profiles
{
    public class UniversityProfile: Profile
    {
        public UniversityProfile()
        {
            CreateMap<University,ViewUniveristy>()
                .ForMember(dest => dest.UniversityId,
                 src => src.MapFrom(Id => Id.UniversityId))
                .ForMember(dest => dest.UniversityName,
                src => src.MapFrom(name => name.UniversityName));
        }
    }
}
