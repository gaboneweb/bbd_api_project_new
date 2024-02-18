namespace UkukhulaAPI.Data.Models.ViewModels
{
    public class vStudentDocuments
    {
        public int? StudentDocumentId { get; set; }

        public string? IdCopy { get; set; } = null!;

        public string? Transcript { get; set; } = null!;

        public string? CurriculumVitae { get; set; } = null!;
    }
}
