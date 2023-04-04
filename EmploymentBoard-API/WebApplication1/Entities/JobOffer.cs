using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BolsaDeTrabajoAPI.Entities
{
    public class JobOffer
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        public bool Active { get; set; }
        public string WorkSchedule { get; set; } = string.Empty;
        public int Experience { get; set; }
        public string JobType { get; set; } = string.Empty;
        public ICollection<Postulation> JobPostulations { get; set; } = new List<Postulation>();

        [ForeignKey("EnterpriseId")]
        public Enterprise OffererEnterprise { get; set; }
        public string EnterpriseId { get; set; }
        public string EnterpriseName { get; set; }
    }
}
