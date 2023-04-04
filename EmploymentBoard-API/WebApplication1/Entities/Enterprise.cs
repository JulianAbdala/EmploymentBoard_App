using BolsaDeTrabajoAPI.Enums;

namespace BolsaDeTrabajoAPI.Entities
{
    public class Enterprise : User
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Cuit { get; set; }
        public string Field { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string ContactName { get; set; }
        public string ContactPosition { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public AccountStatusTypes AccountStatus { get; set; }
        public EnterpriseRelationTypes EnterpriseRelation { get; set; }
        public ICollection<JobOffer> OfferedJobs { get; set; } = new List<JobOffer>();
    }
}
