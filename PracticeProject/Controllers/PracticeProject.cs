using Core.StudentServices;
using Data.Dtos;
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
        public async Task<ActionResult> DeleteStudentAsync( Guid studentId)
        {
            var deletedStudent = await _studentService.RemoveStudentAsync(studentId);
            if(!deletedStudent)
            {
                return BadRequest("Something went wrong");
            }
            return Ok("Successfully deleted student");
        }

        // Optional: Action to retrieve a student by Id
        //[HttpGet("{id}")]
        //public async Task<ActionResult<StudentDto>> GetStudentById(Guid id)
        //{
        //    // Fetch student by id from database and return as StudentDto
        //    // Example: var student = await _context.Students.FindAsync(id);
        //    // Map student entity to StudentDto using AutoMapper
        //    // return _mapper.Map<StudentDto>(student);
        //}
    }


}
