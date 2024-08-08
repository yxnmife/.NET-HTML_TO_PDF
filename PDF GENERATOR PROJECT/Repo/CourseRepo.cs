using Microsoft.EntityFrameworkCore;
using PDF_GENERATOR_PROJECT.Data;
using PDF_GENERATOR_PROJECT.Interfaces;
using PDF_GENERATOR_PROJECT.Models;

namespace PDF_GENERATOR_PROJECT.Repo
{
    public class CourseRepo : ICourseRepo
    {
        private readonly ApplicationDbContext _db;
        public CourseRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Courses>> GetAllCoursesAsync()
        {
            var courses = await _db.CourseTable.ToListAsync();
            if (courses.Count == 0)
            {
                return null;
            }
            return courses;
        }

        public async Task<Courses> RegisterCourseAsync(Courses course)
        {
            if(course == null)
            {
                return null;
            }
            await _db.CourseTable.AddAsync(course);
            await _db.SaveChangesAsync();
            return course;
        }
    }
}
