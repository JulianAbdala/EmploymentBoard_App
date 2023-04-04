namespace BolsaDeTrabajoAPI.Models
{
    public class JobOfferDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        public bool Active { get; set; }
        public string WorkSchedule { get; set; } = string.Empty;
        public int Experience { get; set; }
        public string JobType { get; set; } = string.Empty;
        public ICollection<PostulationDto> JobPostulations { get; set; } = new List<PostulationDto>();
        public EnterpriseDto OffererEnterprise { get; set; }
        public string EnterpriseId { get; set; }
        public string EnterpriseName { get; set; }
    }
}
