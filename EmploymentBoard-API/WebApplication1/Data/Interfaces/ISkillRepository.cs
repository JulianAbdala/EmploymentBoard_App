using BolsaDeTrabajoAPI.Entities;

namespace BolsaDeTrabajoAPI.Data.Interfaces
{
    public interface ISkillRepository
    {
        public IEnumerable<Skill> GetSkills();
        public void AddSkill(Skill skill);
        public IEnumerable<Skill> GetMySkills(string studentId);
        public bool SaveChange();
    }
}
