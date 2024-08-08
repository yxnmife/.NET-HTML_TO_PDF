using PDF_GENERATOR_PROJECT.DTOs.Students;
using PDF_GENERATOR_PROJECT.Models;

namespace PDF_GENERATOR_PROJECT.Mappers
{
    public static class StudentMapper
    {
        public static StudentDTO ToStudentDTO (this Students student)
        {
            return new StudentDTO()
            {
                StudentId = student.StudentId,
               FullName = student.LastName+" "+student.FirstName,
                Age=student.Age
            };
        }
    }
}
