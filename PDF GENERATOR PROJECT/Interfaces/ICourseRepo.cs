using PDF_GENERATOR_PROJECT.Models;

namespace PDF_GENERATOR_PROJECT.Interfaces
{
    public interface ICourseRepo
    {
        Task<List<Courses>> GetAllCoursesAsync();
        Task<Courses> RegisterCourseAsync(Courses course);
    }
      
}
