using BolsaDeTrabajoAPI.Enums;

namespace BolsaDeTrabajoAPI.Models
{
    public class StudentDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int FileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string CareerName { get; set; }
        public string LinkCV { get; set; }
        public byte[]? Curriculum { get; set; }
        public string Cuit { get; set; }
        public AccountStatusTypes AccountStatus { get; set; }

        public ICollection<PostulationDto> Postulations { get; set; } = new List<PostulationDto>();
        //public ICollection<JobOfferDto> SavedJobs { get; set; } = new List<JobOfferDto>();
    }
}
