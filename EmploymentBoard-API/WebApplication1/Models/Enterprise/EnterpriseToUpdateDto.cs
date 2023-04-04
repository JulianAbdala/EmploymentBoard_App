using BolsaDeTrabajoAPI.Enums;
using System.Text.Json.Serialization;

namespace BolsaDeTrabajoAPI.Models
{
    public class EnterpriseToUpdateDto
    {
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string Website { get; set; }
        public string ContactName { get; set; }
        public string ContactPosition { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnterpriseRelationTypes EnterpriseRelation { get; set; }
    }
}
