using Core.StudentServices;
using Data.Dtos;
using Data.Dtos.Update_Dtos;
using Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace PracticeProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("add-student")]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest("Student data is null");
            }


            var createdStudent = await _studentService.AddStudentAsync(studentDto);

            //var createdStudentDto = _mapper.Map<StudentDto>(createdStudent);
            return Ok("Succesfully Added Student");
        }

        [HttpDelete("delete-student")]
        public async Task<ActionResult> DeleteStudentAsync(Guid studentId)
        {
            var deletedStudent = await _studentService.RemoveStudentAsync(studentId);
            if (!deletedStudent)
            {
                return BadRequest("Something went wrong");
            }
            return Ok("Successfully deleted student");
        }

        [HttpPatch("update-basic-info/{studentId}")]
        public async Task<ActionResult> UpdateStudentBasicInfoAsync(Guid studentId, [FromBody] UpdateStudentBasicInfoDto dto)
        {
            var result = await _studentService.UpdateStudentBasicInfoAsync(studentId, dto);
            if (!result) return NotFound($"Student with ID {studentId} not found");
            return NoContent();
        }

        [HttpPatch("update-contact-info/{studentId}")]
        public async Task<ActionResult> UpdateContactInfoAsync(Guid studentId, [FromBody] UpdateContactInfoDto dto)
        {
            var result = await _studentService.UpdateContactInfoAsync(studentId, dto);
            if (!result) return NotFound($"Student with ID {studentId} not found or Contact Info missing");
            return NoContent();
        }

        [HttpPatch("update-academic-info/{studentId}")]
        public async Task<ActionResult> UpdateAcademicInfoAsync(Guid studentId, [FromBody] UpdateAcademicInfoDto dto)
        {
            var result = await _studentService.UpdateAcademicInfoAsync(studentId, dto);
            if (!result) return NotFound($"Student with ID {studentId} not found or Academic Info missing");
            return NoContent();
        }

        [HttpPatch("update-advisor-info/{studentId}")]
        public async Task<ActionResult> UpdateAdvisorInfoAsync(Guid studentId, [FromBody] UpdateAdvisorInfoDto dto)
        {
            var result = await _studentService.UpdateAdvisorInfoAsync(studentId, dto);
            if (!result) return NotFound($"Student with ID {studentId} not found or Advisor Info missing");
            return NoContent();
        }
    }
}
