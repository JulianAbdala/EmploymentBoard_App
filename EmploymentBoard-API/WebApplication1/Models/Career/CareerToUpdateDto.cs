using BolsaDeTrabajoAPI.Enums;
using System.Text.Json.Serialization;

namespace BolsaDeTrabajoAPI.Models
{
    public class CareerToUpdateDto
    {
        public string CareerName { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CareerTypes CareerType { get; set; } = CareerTypes.Tecnicatura;
    }
}
