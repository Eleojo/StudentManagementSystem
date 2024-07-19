using AutoMapper;
using Data.AppDbContext;
using Data.Dtos;
using Data.Model;
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

        public async Task<Student> AddStudentAsync(StudentDto studentDto)
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
            return student;
        }

    }

}
