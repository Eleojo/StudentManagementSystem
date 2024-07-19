using Data.Dtos;
using Data.Dtos.Update_Dtos;
using Data.Model;

namespace Core.StudentServices
{
    public interface IStudentService
    {
        Task<StudentDto> AddStudentAsync(StudentDto studentDto);
        Task<bool> RemoveStudentAsync(Guid studentId);
        Task<bool> UpdateStudentBasicInfoAsync(Guid studentId, UpdateStudentBasicInfoDto dto);
        Task<bool> UpdateContactInfoAsync(Guid studentId, UpdateContactInfoDto dto);
        Task<bool> UpdateAcademicInfoAsync(Guid studentId, UpdateAcademicInfoDto dto);
        Task<bool> UpdateAdvisorInfoAsync(Guid studentId, UpdateAdvisorInfoDto dto);
    }
}