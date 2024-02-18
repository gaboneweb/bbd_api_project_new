using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;

namespace UkukhulaAPI.Data.Services
{
    public class UniversityService
    {
        private UkukhulaContext  _context;

        public UniversityService(UkukhulaContext context)
        {
            _context = context;
        }



        public int GetUniversityIdByUniversityName(string universityName)
        {
            var university = _context.University.FirstOrDefault(n => n.UniversityName == universityName);
            return university.UniversityId;
        }
    }
}
