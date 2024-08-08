namespace PDF_GENERATOR_PROJECT.DTOs.Students
{
    public class StudentDTO
    {
        public Guid StudentId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
