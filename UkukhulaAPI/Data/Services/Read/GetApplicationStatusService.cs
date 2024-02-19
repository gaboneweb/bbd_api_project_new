using UkukhulaAPI.Data.Models;
using UkukhulaAPI.Data.Models.ViewModels;
using UkukhulaAPI.Data.Models.View;
using System.Collections.Generic;

namespace UkukhulaAPI.Data.Services.Read
{
    public class GetApplicationStatusService
    {
        private UkukhulaContext _context;

        public GetApplicationStatusService(UkukhulaContext context)
        {
            _context = context;
        }

        public int GetStatusIdByStatus(string status)
        {
            var _status = _context.ApplicationStatus.FirstOrDefault(n => n.Status == status);
            if (_status != null)
            {
                return _status.StatusId;
            }

            return 0;
        }

        public string GetStatusByStatusId(int statusId)
        {
            var _status = _context.ApplicationStatus.FirstOrDefault(n => n.StatusId == statusId);
            if (_status != null)
            {
                return _status.Status;
            }

            return "";
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

 
    }
}
