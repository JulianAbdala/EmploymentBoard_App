using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolsaDeTrabajoAPI.Entities
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
        public string Level { get; set; }
        [ForeignKey("StudentId")]
        [Required]
        public Student? Student { get; set; }
        public string? StudentId { get; set; }
    }
}
