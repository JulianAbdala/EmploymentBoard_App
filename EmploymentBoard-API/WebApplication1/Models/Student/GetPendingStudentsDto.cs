using BolsaDeTrabajoAPI.Enums;

namespace BolsaDeTrabajoAPI.Models
{
    public class GetPendingStudentsDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FileNumber { get; set; }
        public AccountStatusTypes AccountStatus { get; set; }
    }
}
