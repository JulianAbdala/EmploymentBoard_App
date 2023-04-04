using BolsaDeTrabajoAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolsaDeTrabajoAPI.Entities
{
    public class Student : User
    {

        public int FileNumber { get; set; }
        public byte[]? Curriculum { get; set; }
        public string CurrentCity { get; set; }
        public string Name { get; set; }
        public string PersonalId { get; set; }
        public string Cuit { get; set; }
        public AccountStatusTypes AccountStatus { get; set; }
        public ICollection<Postulation> Postulations { get; set; } = new List<Postulation>();
        public ICollection<JobOffer> SavedJobs { get; set; } = new List<JobOffer>();


        [ForeignKey("CareerId")]
        public Career? Career { get; set; }
        public string? CareerName { get; set; }
    }
}
