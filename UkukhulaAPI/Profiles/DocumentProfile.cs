using AutoMapper;
using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;

namespace UkukhulaAPI.Profiles
{
    public class DocumentProfile: Profile
    {
        public DocumentProfile() {
            CreateMap<StudentBursaryDocument, vStudentDocuments>();
        }
    }
}
