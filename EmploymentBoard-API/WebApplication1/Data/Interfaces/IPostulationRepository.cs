using BolsaDeTrabajoAPI.Entities;
using BolsaDeTrabajoAPI.Models;

namespace BolsaDeTrabajoAPI.Data.Interfaces
{
    public interface IPostulationRepository
    {
        public void AddPostulation(Postulation postulation);
        public Postulation? GetPostulation(int postulationId);
        public bool SaveChange();
        public bool CanPostulate(PostulationToCreateDto postulationDto);
        public List<JobOffer> GetStudentPostulations(string studentId);
        IEnumerable<Postulation> GetPostulations();

        public List<Postulation> GetJobOfferPostulations(int jobOfferId);
    }
}
