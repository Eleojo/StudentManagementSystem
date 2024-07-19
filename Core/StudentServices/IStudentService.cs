using Data.Dtos;
using Data.Model;

namespace Core.StudentServices
{
    public interface IStudentService
    {
        Task<Student> AddStudentAsync(StudentDto studentDto);
    }
}