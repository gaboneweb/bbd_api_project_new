namespace UkukhulaAPI.Data.Models.ViewModels
{
    public class vStudent
    {
        public int StudentId { get; set; }
        public string CourseOfStudy { get; set; } = null!;

        public vRace Race { get; set; }

        public vUser User { get; set; }

        public vDepartment Department { get; set; }

        public vUniveristy Univeristy { get; set; }

        public vStudentDocuments Documents { get; set; }

    }
}
