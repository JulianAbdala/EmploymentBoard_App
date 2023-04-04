using BolsaDeTrabajoAPI.Enums;

namespace BolsaDeTrabajoAPI.Models
{
    public class StudentStatusUpdateDto
    {
        public string Id { get; set; }
        public AccountStatusTypes AccountStatus { get; set; }
    }
}
