using AutoMapper;
using BolsaDeTrabajoAPI.Models;

namespace BolsaDeTrabajoAPI.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Entities.Student, StudentDto>();
            CreateMap<StudentDto, Entities.Student>();
            CreateMap<StudentToUpdateDto, Entities.Student>();
            CreateMap<Entities.Student, StudentToUpdateDto>();
            CreateMap<GetStudentProfileInfo, Entities.Student>();
            CreateMap<Entities.Student, GetStudentProfileInfo>();
            CreateMap<GetPendingStudentsDto, Entities.Student>();
            CreateMap<Entities.Student, GetPendingStudentsDto>();
            CreateMap<StudentStatusUpdateDto, Entities.Student>();
            CreateMap<Entities.Student, StudentStatusUpdateDto>();
            CreateMap<PostulationDto, Entities.Postulation>();
            CreateMap<Entities.Postulation, PostulationDto>();
            CreateMap<PostulationDto, Entities.Student>();
        }
    }
}
