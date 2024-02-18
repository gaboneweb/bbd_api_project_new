using System;

namespace UkukhulaAPI.Data.Models.View
{
    public class ApplicationVm
    {
        public string ApplicationMotivation { get; set; }
        public string ApplicationRejectionReason { get; set; }
        public decimal BursaryAmount { get; set; }
        public int AverageMark { get; set; }
        public DateOnly ApplicationDate { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentUniversity { get; set; }
        public string CourseOfStudy { get; set; }
        public string race { get; set; }
        // public decimal YearBudget { get; set; }
        // public decimal CapAmountPerStudent { get; set; }
        public string Status { get; set; }
        public string Department { get; set; }
        public string HeadOfDepartmentUniversity { get; set; }
        public string HeadOfDepartmentFirstName { get; set; }
        public string HeadOfDepartmentLastName { get; set; }
    }
}
