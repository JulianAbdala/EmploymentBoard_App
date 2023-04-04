using System.ComponentModel.DataAnnotations;

namespace BolsaDeTrabajoAPI.Models
{
    public class PostulationToCreateDto
    {
        [Required]
        public string Presentation { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Required]
        public string? LinkCV { get; set; }
        [Required]
        public int JobOfferId { get; set; }
        [Required]
        public string? StudentId { get; set; }
    }
}
