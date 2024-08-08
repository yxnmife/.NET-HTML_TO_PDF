using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDF_GENERATOR_PROJECT.Models
{
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //auto increments primary key
        public Guid StudentId { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; }  = string.Empty;
        public int Age { get; set; }
        public DateTime DOB { get; set; }
    }
}
