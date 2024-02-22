

using UkukhulaAPI.Data.Models.View;

namespace UkukhulaAPI.Controllers.Request;

public class TokenGenerationRequest
    {
        public required LoginVm User { get; set; }
        // public required ContactVm Contact { get; set; }
    }