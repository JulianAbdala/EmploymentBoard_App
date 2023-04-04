using System.ComponentModel.DataAnnotations;

namespace BolsaDeTrabajoAPI.Models
{
    public class JobOfferToCreateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime? EndDate { get; set; }
        public bool Active { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public string WorkSchedule { get; set; } = string.Empty;
        [Required]
        public string JobType { get; set; } = string.Empty;
        [Required]
        public string EnterpriseId { get; set; }
        [Required]
        public string EnterpriseName { get; set; }
    }
}
