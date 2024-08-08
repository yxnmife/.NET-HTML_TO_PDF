using PDF_GENERATOR_PROJECT.DTOs.Students;
using PDF_GENERATOR_PROJECT.Models;

namespace PDF_GENERATOR_PROJECT.Interfaces
{
    public interface IStudentRepo
    {
        Task<List<StudentDTO>> GetAllStudentsAsync();
        Task<Students> RegisterStudentsAsync(CreateStudentsDTO student);
    }
}
