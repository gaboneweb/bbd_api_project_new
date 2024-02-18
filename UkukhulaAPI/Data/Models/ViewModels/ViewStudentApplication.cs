 namespace UkukhulaAPI.Data.Models.ViewModels
{
    public class ViewStudentApplication
    {
        public int ApplicationId { get; set; }

        public string ApplicationMotivation { get; set; } = null!;

        public string ApplicationRejectionReason { get; set; } = null!;

        public decimal BursaryAmount { get; set; }

        public int BursaryDetailsID { get; set; }

        public ViewStudent Student { get; set; } = null!;

        public ViewApplicationStatus ApplicationStatus { get; set; } = null!;

        public ViewHeadOfDepartment HeadOfDepartment { get; set; } = null!;



    }
}
