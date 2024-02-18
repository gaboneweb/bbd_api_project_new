namespace UkukhulaAPI.Data.Models.ViewModels
{
    public class ViewStudent
    {
        public int StudentId { get; set; }
        public string CourseOfStudy { get; set; } = null!;

        public ViewRace Race { get; set; }

        public ViewUser User { get; set; }

        public ViewDepartment Department { get; set; }

        public ViewUniveristy Univeristy { get; set; }

        public ViewStudentDocuments Documents { get; set; }

    }
}
