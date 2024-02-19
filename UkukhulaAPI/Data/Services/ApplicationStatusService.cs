using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Services
{
    public class ApplicationStatusService
    {
        private UkukhulaContext _context;

        public ApplicationStatusService(UkukhulaContext context)
        {
            _context = context;
        }


        public List<ApplicationStatus> GetAllApplicationStatuses()
        {

            return _context.ApplicationStatus.ToList();

        }

        public List<string> getListApplicationStatus()
        {

            var allApplicationStatusTable = GetAllApplicationStatuses();
            
            List<string> listApplicationStatus = new List<string>();


            foreach (var applicationStatus in allApplicationStatusTable)
            {
                listApplicationStatus.Add(applicationStatus.Status);
            }

            return listApplicationStatus;
        }

        public IDictionary<int, string> GetDictIDApplicationStatus()
        {
            var allApplicationStatusTable = GetAllApplicationStatuses();

            IDictionary<int, string> dictIDApplicationStatus = new Dictionary<int, string>();


            foreach (var applicationStatus in allApplicationStatusTable)
            {
                dictIDApplicationStatus.Add(applicationStatus.StatusId, applicationStatus.Status);
            }

            return dictIDApplicationStatus;
        }

        public int GetStatusIdByStatus(string status)
        {
            var _status = _context.ApplicationStatus.FirstOrDefault(n => n.Status == status);
            return _status.StatusId;
        }

        public string GetStatusByStatusId(int statusId)
        {
            var _status = _context.ApplicationStatus.FirstOrDefault(n => n.StatusId == statusId);
            return _status.Status;
        }
    }
}
