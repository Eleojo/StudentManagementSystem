using AutoMapper;
using Data.AppDbContext;
using Data.Dtos;
using Data.Dtos.Update_Dtos;
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


        public async Task<bool> UpdateStudentBasicInfoAsync(Guid studentId, UpdateStudentBasicInfoDto dto)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);
            if (student == null) return false;

            if (dto.FirstName != null) student.FirstName = dto.FirstName;
            if (dto.LastName != null) student.LastName = dto.LastName;
            if (dto.DateOfBirth.HasValue) student.DateOfBirth = dto.DateOfBirth.Value;
            if (dto.Gender != null) student.Gender = dto.Gender;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateContactInfoAsync(Guid studentId, UpdateContactInfoDto dto)
        {
            var student = await _context.Students.Include(s => s.ContactInfo)
                                                 .FirstOrDefaultAsync(s => s.StudentId == studentId);
            if (student == null || student.ContactInfo == null) return false;

            if (dto.Email != null) student.ContactInfo.Email = dto.Email;
            if (dto.PhoneNumber != null) student.ContactInfo.PhoneNumber = dto.PhoneNumber;
            if (dto.Address != null) student.ContactInfo.Address = dto.Address;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAcademicInfoAsync(Guid studentId, UpdateAcademicInfoDto dto)
        {
            var student = await _context.Students.Include(s => s.AcademicInfo)
                                                 .FirstOrDefaultAsync(s => s.StudentId == studentId);
            if (student == null || student.AcademicInfo == null) return false;

            if (dto.Course != null) student.AcademicInfo.Course = dto.Course;
            if (dto.YearOfStudy != null) student.AcademicInfo.YearOfStudy = dto.YearOfStudy;
            if (dto.GPA.HasValue) student.AcademicInfo.GPA = dto.GPA.Value;
            if (dto.Major != null) student.AcademicInfo.Major = dto.Major;
            if (dto.Minor != null) student.AcademicInfo.Minor = dto.Minor;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAdvisorInfoAsync(Guid studentId, UpdateAdvisorInfoDto dto)
        {
            var student = await _context.Students.Include(s => s.AdvisorInfo)
                                                 .FirstOrDefaultAsync(s => s.StudentId == studentId);
            if (student == null || student.AdvisorInfo == null) return false;

            if (dto.AdvisorFirstName != null) student.AdvisorInfo.AdvisorFirstName = dto.AdvisorFirstName;
            if (dto.AdvisorLastName != null) student.AdvisorInfo.AdvisorLastName = dto.AdvisorLastName;

            await _context.SaveChangesAsync();
            return true;
        }



        //public async Task<StudentDto> UpdateStudentInfoAsync(Guid studentId, StudentDto studentDto)
        //{
        //    var student = await _context.Students.Include(s => s.ContactInfo)
        //                      .Include(s => s.AcademicInfo)
        //                      .Include(s => s.AdvisorInfo)
        //                      .FirstOrDefaultAsync(s => s.StudentId == studentId);

        //    if (student == null)
        //    {
        //        return null;
        //    }

        //    UpdateBasicInfo(student, studentDto);
        //    UpdateContactInfo(student, studentDto.ContactInfo);
        //    UpdateAcademicInfo(student, studentDto.AcademicInfo);
        //    UpdateAdvisorInfo(student, studentDto.AdvisorInfo);

        //    await _context.SaveChangesAsync();

        //    var updatedStudentInfo = _mapper.Map<StudentDto>(student);
        //    return updatedStudentInfo;
        //}

        //private void UpdateBasicInfo(Student student, StudentDto studentDto)
        //{
        //    student.FirstName = studentDto.FirstName;
        //    student.LastName = studentDto.LastName;
        //    student.Gender = studentDto.Gender;
        //    student.DateOfBirth = studentDto.DateOfBirth;
        //}
        //private void UpdateContactInfo(Student student, ContactInfoDto contactInfoDto)
        //{
        //    if (student.ContactInfo != null && contactInfoDto != null)
        //    {
        //        student.ContactInfo.Email = contactInfoDto.Email;
        //        student.ContactInfo.Address = contactInfoDto.Address;
        //        student.ContactInfo.PhoneNumber = contactInfoDto.PhoneNumber;
        //    }
        //}
        //private void UpdateAcademicInfo(Student student, AcademicInfoDto academicInfoDto)
        //{
        //    if (student.AcademicInfo != null && academicInfoDto != null)
        //    {
        //        student.AcademicInfo.GPA = academicInfoDto.GPA;
        //        student.AcademicInfo.Major = academicInfoDto.Major;
        //        student.AcademicInfo.Course = academicInfoDto.Course;
        //        student.AcademicInfo.YearOfStudy = academicInfoDto.YearOfStudy;
        //        student.AcademicInfo.Minor = academicInfoDto.Minor;
        //    }
        //}
        //private void UpdateAdvisorInfo(Student student, AdvisorInfoDto advisorInfoDto)
        //{
        //    if (student.AdvisorInfo != null && advisorInfoDto != null)
        //    {
        //        student.AdvisorInfo.AdvisorFirstName = advisorInfoDto.AdvisorFirstName;
        //        student.AdvisorInfo.AdvisorLastName = advisorInfoDto.AdvisorLastName;
        //    }
        //}





        //public async Task<StudentDto> UpdateStudentInfoAsync(Guid studentId, StudentDto studentDto)
        //{
        //    var student = await _context.Students.Include(s => s.ContactInfo)
        //                      .Include (s => s.AcademicInfo)
        //                      .Include(s=> s.AdvisorInfo)
        //                      .FirstOrDefaultAsync(s=> s.StudentId == studentId);

        //    if(student == null)
        //    {
        //        return null;
        //    }

        //    //Update student basic info
        //    student.FirstName = studentDto.FirstName;
        //    student.LastName = studentDto.LastName;
        //    student.Gender = studentDto.Gender;
        //    student.DateOfBirth = studentDto.DateOfBirth;

        //    if (student.ContactInfo != null && studentDto.ContactInfo != null)
        //    {
        //        student.AcademicInfo.GPA = studentDto.AcademicInfo.GPA;
        //        student.AcademicInfo.Major = studentDto.AcademicInfo.Major;
        //        student.AcademicInfo.Course = studentDto.AcademicInfo.Course;
        //        student.AcademicInfo.YearOfStudy = studentDto.AcademicInfo.YearOfStudy;
        //        student.AcademicInfo.Minor = studentDto.AcademicInfo.Minor;
        //    }

        //    if(student.ContactInfo != null && studentDto.ContactInfo != null)
        //    {
        //        student.ContactInfo.Email = studentDto.ContactInfo.Email;   
        //        student.ContactInfo.Address = studentDto.ContactInfo.Address;
        //        student.ContactInfo.PhoneNumber = studentDto.ContactInfo.PhoneNumber;
        //    }
        //    if( student.AdvisorInfo != null && studentDto.AdvisorInfo != null)
        //    {
        //        student.AdvisorInfo.AdvisorFirstName = studentDto.FirstName;
        //        student.AdvisorInfo.AdvisorLastName = studentDto.LastName;
        //    }

        //    await _context.SaveChangesAsync();
        //    var updatedStudentInfo = _mapper.Map<StudentDto>(student);
        //    return updatedStudentInfo;
        //}

    }


}
