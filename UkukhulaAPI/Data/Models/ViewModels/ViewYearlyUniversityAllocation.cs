namespace UkukhulaAPI.Data.Models.ViewModels
{
    public class ViewYearlyUniversityAllocation
    {
        public int AllocationId { get; set; }

        public decimal AllocatedAmount { get; set; }


        public decimal TotalAmountsSpent { get; set; }

        public int Year { get; set; }

        public ViewUniversity? University { get; set; }
    }
}
