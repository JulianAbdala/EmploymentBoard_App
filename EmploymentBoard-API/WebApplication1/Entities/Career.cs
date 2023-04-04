using BolsaDeTrabajoAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace BolsaDeTrabajoAPI.Entities
{
    public class Career
    {
        [Key]
        public int CareerId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CareerName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public CareerTypes CareerType { get; set; }
    }
}
