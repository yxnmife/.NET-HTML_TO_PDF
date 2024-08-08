using Microsoft.EntityFrameworkCore;
using PDF_GENERATOR_PROJECT.Data;
using PDF_GENERATOR_PROJECT.DTOs.Students;
using PDF_GENERATOR_PROJECT.Interfaces;
using PDF_GENERATOR_PROJECT.Mappers;
using PDF_GENERATOR_PROJECT.Models;

namespace PDF_GENERATOR_PROJECT.Repo
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationDbContext _db;
        public StudentRepo(ApplicationDbContext db)
        {
            _db = db;       }
        public async Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            var students = await _db.StudentsTable.Select(x=>x.ToStudentDTO()).ToListAsync();
            if (students == null)
            {
                return null;
            }
            return students;
        }

        public async Task<Students> RegisterStudentsAsync(CreateStudentsDTO student)
        {
            var studentModel = new Students();
            studentModel.LastName= student.LastName;
            studentModel.FirstName= student.FirstName;
            studentModel.DOB = student.DOB;
            var age = DateTime.Now.Year - student.DOB.Year;
            studentModel.Age = age;

            if (studentModel == null)
            {
                return null;
            }

            await _db.StudentsTable.AddAsync(studentModel);
            await _db.SaveChangesAsync();
            return studentModel;
        }

    }
}
