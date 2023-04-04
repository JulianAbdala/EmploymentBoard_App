using BolsaDeTrabajoAPI.Models.Skills;

namespace BolsaDeTrabajoAPI.Services.Interfaces
{
    public interface ISkillServices
    {
        public IEnumerable<SkillDto> GetMySkills(string id);
    }
}
