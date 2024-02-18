

using UkukhulaAPI.Data.Models.View;

namespace UkukhulaAPI.Controllers.Request;

public class AddStudentApplicationRequest
    {
        public required StudentRegistrationVm User { get; set; }
        public required ContactVm Contact { get; set; }
    }