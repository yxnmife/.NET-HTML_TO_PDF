using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDF_GENERATOR_PROJECT.Models
{
    public class Courses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto increments key
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }

    }
}
