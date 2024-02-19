using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;


namespace UkukhulaAPI.Data.Services
{
    public class UniversityApplicationService
    {
        private UkukhulaContext _context;
        public UniversityApplicationService(UkukhulaContext context)
        {
            _context = context;
        }

        public void ApplyAsUniversity(UniversityApplicationVM universityApplication)
        {
            var _contact = new Contact()
            {
                ContactNumber = universityApplication.ContactNumber,
                Email = universityApplication.Email

            };
            _context.Add(_contact);
            _context.SaveChanges();

            var _user = new User()
            {
                FirstName = universityApplication.FirstName,
                LastName = universityApplication.LastName,
                Idnumber = universityApplication.Idnumber,
                ContactId = _contact.ContactId
            };
            _context.Add(_user);
            _context.SaveChanges();


            var _university = new University()
            {
                UniversityName = universityApplication.UniversityName,
                UserId = _user.UserId,
            };
            _context.Add(_university);
            _context.SaveChanges();

            var _universityApplication = new UniversityApplication()
            {
                UniversityId = _university.UniversityId,
                Motivation = universityApplication.Motivation,
                StatusId = 1,
                ReviewerComment = "N/A",
                ApplicationDate = DateTime.Now
            };

            _context.Add(_universityApplication);
            _context.SaveChanges();
        }

        public UniversityStatusVM GetUniversityApplicationStatusByUniversityName(string universityName)
        {
            var university = _context.University.FirstOrDefault(n => n.UniversityName == universityName);
            if (university == null)
            {
                return null;
            }
            var universityId = university.UniversityId;
            
            var universityApplication = _context.UniversityApplication.FirstOrDefault(n => n.UniversityId == universityId);
            if (universityApplication == null)
            {
                return null;
            }
            var reviewerComment = universityApplication.ReviewerComment;
            var statusId = universityApplication.StatusId;

            var applicationStatus = _context.ApplicationStatus.FirstOrDefault(n => n.StatusId == statusId);
            var status = applicationStatus.Status;

            var _universityStatus = new UniversityStatusVM()
            {
                Status = status,
                ReviewerComment = reviewerComment
            };

            return _universityStatus;
        }
    }
}
