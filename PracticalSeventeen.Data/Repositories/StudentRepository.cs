using Microsoft.EntityFrameworkCore;
using PracticalSeventeen.Data.Interfaces;
using PracticalSeventeen.Data.Models;

namespace PracticalSeventeen.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDBContext _db;
        public StudentRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var students = await _db.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            Student data = await _db.Students.FirstOrDefaultAsync(s => s.Id == studentId);
            return data;
        }

        public async Task<int> InsertStudentAsync(Student student)
        {
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
            int id = await _db.Students.MaxAsync(s => s.Id);
            return id;
        }

        public async Task<bool> UpdateStudentAsync(int studentId, Student student)
        {
            var data = await _db.Students.FirstOrDefaultAsync(s => s.Id == studentId);

            if (data == null) return false;

            data.FirstName = student.FirstName;
            data.MiddleName = student.MiddleName;
            data.LastName = student.LastName;
            data.MobileNumber = student.MobileNumber;
            data.Address = student.Address;
            data.DOB = student.DOB;
            data.Gender = student.Gender;
            _db.Students.Update(data);
            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            var data = await _db.Students.FirstOrDefaultAsync(s => s.Id == studentId);
            if (data == null) return false;
            _db.Remove(data);
            await _db.SaveChangesAsync();   
            return true;
        }

    }
}
