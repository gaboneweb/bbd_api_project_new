using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;

namespace UkukhulaAPI.Data.Services.Read
{
    public class GetUniversityService
    {
        private UkukhulaContext  _context;

        public GetUniversityService(UkukhulaContext context)
        {
            _context = context;
        }


        //public int GetUniversityIdByUniversityName(string universityName)

        public string GetUniversityNameByUniversityId(int universityId)
        {
            try
            {
                var university = _context.University.FirstOrDefault(n => n.UniversityId == universityId);
                return university.UniversityName;
            } 
            catch (Exception ex)
            {
                return "";
            }
}

        public int GetUserIdByUniversityName(string universityName)
        {
            try
            {
                var university = _context.University.FirstOrDefault(n => n.UniversityName == universityName);
                return university.UserId;
            } 
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<University> GetAllUniversities()
        {

            return _context.University.ToList();

        }
    }
}
