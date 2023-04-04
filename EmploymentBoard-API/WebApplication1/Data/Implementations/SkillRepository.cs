using BolsaDeTrabajoAPI.Data.Interfaces;
using BolsaDeTrabajoAPI.DBContexts;
using BolsaDeTrabajoAPI.Entities;

namespace BolsaDeTrabajoAPI.Data.Implementations
{
    public class SkillRepository : ISkillRepository
    {
        private readonly BDTContext _context;
        public SkillRepository(BDTContext context)
        {
            _context = context;
        }
        public IEnumerable<Skill> GetSkills()
        {
            return _context.Skills.OrderBy(x => x.SkillId).ToList(); ;
        }

        public void AddSkill(Skill newSkill)
        {
            _context.Skills.Add(newSkill);
        }

        public IEnumerable<Skill> GetMySkills(string studentId)
        {
            return _context.Skills.Where(x => x.StudentId == studentId).OrderBy(x => x.SkillId).ToList(); ;
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
