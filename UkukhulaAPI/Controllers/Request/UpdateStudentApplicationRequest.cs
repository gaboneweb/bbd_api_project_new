

using UkukhulaAPI.Data.Models.View;

namespace UkukhulaAPI.Controllers.Request;

public class UpdateStudentApplicationRequest
    {
        public required StudentUpdateVm User { get; set; }
        // public required ContactVm Contact { get; set; }
    }