using Data.Dtos;
using Data.Model;

namespace Core.StudentServices
{
    public interface IStudentService
    {
        Task<StudentDto> AddStudentAsync(StudentDto studentDto);
        Task<bool> RemoveStudentAsync(Guid studentId);
        Task<StudentDto> UpdateStudentInfoAsync(Guid studentId, StudentDto studentDto);
    }
}