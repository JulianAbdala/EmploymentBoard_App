using BolsaDeTrabajoAPI.Enums;

namespace BolsaDeTrabajoAPI.Models.Enterprise
{
    public class GetPendingEnterprisesDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Cuit { get; set; }
        public string Field { get; set; }
        public AccountStatusTypes AccountStatus { get; set; }
    }
}
