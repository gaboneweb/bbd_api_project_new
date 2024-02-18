 namespace UkukhulaAPI.Data.Models.ViewModels
{
    public class vStudentApplication
    {
        public int ApplicationId { get; set; }

        public string ApplicationMotivation { get; set; } = null!;

        public string ApplicationRejectionReason { get; set; } = null!;

        public decimal BursaryAmount { get; set; }

        public int BursaryDetailsID { get; set; }

        public vStudent Student { get; set; } = null!;

        public vApplicationStatus ApplicationStatus { get; set; }

        public vHeadOfDepartment HeadOfDepartment { get; set; }



    }
}
