using PracticalSeventeen.Data.Models;

namespace PracticalSeventeen.Data.Interfaces
{
    public interface IStudentRepository
    {
        /// <summary>
        /// Return all students
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetAllStudentsAsync();

        /// <summary>
        /// Return student by Id
        /// </summary>
        /// <param name="studentId">Id of student</param>
        /// <returns></returns>
        Task<Student> GetStudentByIdAsync(int studentId);

        /// <summary>
        /// Insert new student data
        /// </summary>
        /// <param name="student">Student type object</param>
        /// <returns>newly inserted StudentId</returns>
        Task<int> InsertStudentAsync(Student student);

        /// <summary>
        /// Update existing details of student
        /// </summary>
        /// <param name="student">Student type object</param>
        /// <returns>Updated student object</returns>
        Task<bool> UpdateStudentAsync(int studentId, Student student);

        /// <summary>
        /// Delete student record
        /// </summary>
        /// <param name="studentId">StudentId</param>
        /// <returns>assertion of student delete</returns>
        Task<bool> DeleteStudentAsync(int studentId);

    }
}
