using AutoMapper;
using Data.Dtos;
using Data.Model;

namespace PracticeProject
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<StudentDto, Student>().ReverseMap();
            CreateMap<ContactInfoDto, ContactInfo>().ReverseMap();
            CreateMap<AcademicInfoDto, AcademicInfo>().ReverseMap();
            CreateMap<AdvisorInfoDto, AdvisorInfo>().ReverseMap();
        }

    }
}
