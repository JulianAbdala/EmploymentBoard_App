using AutoMapper;
using BolsaDeTrabajoAPI.Models.Skills;

namespace BolsaDeTrabajoAPI.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<Entities.Skill, SkillDto>();
            CreateMap<SkillDto, Entities.Skill>();
        }
    }
}
