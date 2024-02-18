using AutoMapper;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;

namespace UkukhulaAPI.Profiles
{
    public class ApplicationStatusProfile : Profile
    {
        public ApplicationStatusProfile() {
            CreateMap<ApplicationStatus, vApplicationStatus>()
                .ForMember(dest => dest.StatusId, src => src.MapFrom( app => app.StatusId))
                .ForMember(dest => dest.Status, src => src.MapFrom(app => app.Status));
        }

    }

}
