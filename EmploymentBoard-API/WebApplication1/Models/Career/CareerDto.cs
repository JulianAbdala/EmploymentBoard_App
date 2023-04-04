using BolsaDeTrabajoAPI.Enums;
using System.Text.Json.Serialization;

namespace BolsaDeTrabajoAPI.Models
{
    public class CareerDto
    {
        public int CareerId { get; set; }
        public string CareerName { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CareerTypes CareerType { get; set; } = CareerTypes.Tecnicatura;

    }


}
