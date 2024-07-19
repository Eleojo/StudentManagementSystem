using AutoMapper;
using Data.AppDbContext;
using Data.Dtos;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper; // Assuming you're using AutoMapper

        public StudentService(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentDto> AddStudentAsync(StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            student.StudentId = Guid.NewGuid();
            student.LastUpdated = DateTime.Now;
            

            if (student.ContactInfo != null)
            {
                student.ContactInfo.Id = Guid.NewGuid(); // Generate new ID for ContactInfo
                _context.ContactInfos.Add(student.ContactInfo);
                student.ContactInfoId = student.ContactInfo.Id; // Link ContactInfo
            }

            if (student.AcademicInfo != null)
            {
                student.AcademicInfo.Id = Guid.NewGuid(); // Generate new ID for AcademicInfo
                student.AcademicInfo.EnrollmentDate = DateTime.Now; // Set the enrollment date to now
                _context.AcademicInfos.Add(student.AcademicInfo);
                student.AcademicInfoId = student.AcademicInfo.Id; // Link AcademicInfo
            }

            if (student.AdvisorInfo != null)
            {
                student.AdvisorInfo.Id = Guid.NewGuid(); // Generate new ID for AdvisorInfo
                _context.AdvisorInfos.Add(student.AdvisorInfo);
                student.AdvisorInfoId = student.AdvisorInfo.Id; // Link AdvisorInfo
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return studentDto;
        }

        public async Task<bool> RemoveStudentAsync(Guid studentId)
        {
            // Find the student by their ID
            var student = await _context.Students
                                        .Include(s => s.ContactInfo)
                                        .Include(s => s.AcademicInfo)
                                        .Include(s => s.AdvisorInfo)
                                        .FirstOrDefaultAsync(s => s.StudentId == studentId);
            if (student == null)
            {
                return false; 
            }
        
            if (student.ContactInfo != null)
            {
                _context.ContactInfos.Remove(student.ContactInfo);
            }
            if (student.AcademicInfo != null)
            {
                _context.AcademicInfos.Remove(student.AcademicInfo);
            }
            if (student.AdvisorInfo !=null)
            {
                _context.AdvisorInfos.Remove(student.AdvisorInfo);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<StudentDto> UpdateStudentInfoAsync(Guid studentId, StudentDto studentDto)
        {
            var student = await _context.Students.Include(s => s.ContactInfo)
                              .Include (s => s.AcademicInfo)
                              .Include(s=> s.AdvisorInfo)
                              .FirstOrDefaultAsync(s=> s.StudentId == studentId);

            if(student == null)
            {
                return null;
            }

            //Update student basic info
            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;
            student.Gender = studentDto.Gender;
            student.DateOfBirth = studentDto.DateOfBirth;

            if (student.ContactInfo != null && studentDto.ContactInfo != null)
            {
                student.AcademicInfo.GPA = studentDto.AcademicInfo.GPA;
                student.AcademicInfo.Major = studentDto.AcademicInfo.Major;
                student.AcademicInfo.Course = studentDto.AcademicInfo.Course;
                student.AcademicInfo.YearOfStudy = studentDto.AcademicInfo.YearOfStudy;
                student.AcademicInfo.Minor = studentDto.AcademicInfo.Minor;
            }

            if(student.ContactInfo != null && studentDto.ContactInfo != null)
            {
                student.ContactInfo.Email = studentDto.ContactInfo.Email;   
                student.ContactInfo.Address = studentDto.ContactInfo.Address;
                student.ContactInfo.PhoneNumber = studentDto.ContactInfo.PhoneNumber;
            }
            if( student.AdvisorInfo != null && studentDto.AdvisorInfo != null)
            {
                student.AdvisorInfo.AdvisorFirstName = studentDto.FirstName;
                student.AdvisorInfo.AdvisorLastName = studentDto.LastName;
            }

            await _context.SaveChangesAsync();
            var updatedStudentInfo = _mapper.Map<StudentDto>(student);
            return updatedStudentInfo;
        }

    }


}
