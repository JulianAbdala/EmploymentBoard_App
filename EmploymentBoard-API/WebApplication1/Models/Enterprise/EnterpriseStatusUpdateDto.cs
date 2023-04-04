using BolsaDeTrabajoAPI.Enums;

namespace BolsaDeTrabajoAPI.Models.Enterprise
{
    public class EnterpriseStatusUpdateDto
    {
        public string Id { get; set; }
        public AccountStatusTypes AccountStatus { get; set; }

    }
}
