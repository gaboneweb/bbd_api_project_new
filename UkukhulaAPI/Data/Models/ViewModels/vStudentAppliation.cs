namespace UkukhulaAPI.Data.Models.ViewModels
{
    public class vStudentAppliation
    {
        public int ApplicationId { get; set; }

        public string ApplicationMotivation { get; set; } = null!;

        public string ApplicationRejectionReason { get; set; } = null!;

        public decimal BursaryAmount { get; set; }

        public int BursaryDetailsID { get; set; }

        public vStudent Student { get; set; }


       
    }
}
