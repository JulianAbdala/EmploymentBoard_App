using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolsaDeTrabajoAPI.Entities
{
    public class Postulation
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string? Presentation { get; set; }
        public string? LinkCV { get; set; }

        [ForeignKey("JobOfferId")]
        [Required]
        public JobOffer? JobOfferPostulation { get; set; }
        public int JobOfferId { get; set; }

        [ForeignKey("StudentId")]
        [Required]
        public Student? Student { get; set; }
        public string? StudentId { get; set; }

    }
}
