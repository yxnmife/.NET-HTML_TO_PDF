using Microsoft.EntityFrameworkCore;
using PDF_GENERATOR_PROJECT.Models;

namespace PDF_GENERATOR_PROJECT.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Courses> CourseTable { get; set; }
        public DbSet<Students> StudentsTable { get; set;}
    }
}
