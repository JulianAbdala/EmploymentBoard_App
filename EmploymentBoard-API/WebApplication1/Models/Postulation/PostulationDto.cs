
namespace BolsaDeTrabajoAPI.Models
{
    public class PostulationDto
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string Presentation { get; set; }
        public string LinkCV { get; set; }
        public int JobOfferId { get; set; }
        public string StudentId { get; set; }
    }
}
