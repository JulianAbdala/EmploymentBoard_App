using AutoMapper;
using BolsaDeTrabajoAPI.Data.Interfaces;
using BolsaDeTrabajoAPI.Entities;
using BolsaDeTrabajoAPI.Models.Skills;
using BolsaDeTrabajoAPI.Services.Interfaces;

namespace BolsaDeTrabajoAPI.Services.Implementations
{
    public class SkillServices : ISkillServices
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;

        public SkillServices(IMapper mapper, ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public IEnumerable<SkillDto> GetSkills()
        {
            var skills = _skillRepository.GetSkills();
            return _mapper.Map<IEnumerable<SkillDto>>(skills);
        }

        public IEnumerable<SkillDto> GetMySkills(string id)
        {
            var skills = _skillRepository.GetMySkills(id);
            return _mapper.Map<IEnumerable<SkillDto>>(skills);
        }


        public SkillDto CreateSkill(SkillToCreateDto SkillToCreateDto)
        {
            var newSkill = _mapper.Map<Skill>(SkillToCreateDto);
            _skillRepository.AddSkill(newSkill);
            _skillRepository.SaveChange();

            return _mapper.Map<SkillDto>(newSkill);
        }


    }
}
