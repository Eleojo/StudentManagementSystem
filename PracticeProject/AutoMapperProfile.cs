using AutoMapper;
using Data.Dtos;
using Data.Dtos.Update_Dtos;
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
            CreateMap<UpdateStudentBasicDto, Student>().ReverseMap();
            CreateMap<UpdateContactInfoDto,ContactInfo>().ReverseMap();
            CreateMap<UpdateAcademicInfoDto,AcademicInfo>().ReverseMap();
            CreateMap<UpdateAdvisorInfoDto,AdvisorInfo>().ReverseMap();
        }

    }
}
