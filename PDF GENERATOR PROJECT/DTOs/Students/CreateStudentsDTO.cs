using System.ComponentModel.DataAnnotations;

namespace PDF_GENERATOR_PROJECT.DTOs.Students
{
    public class CreateStudentsDTO
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public DateTime DOB { get; set; }


    }
}
