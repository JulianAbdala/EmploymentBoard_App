using BolsaDeTrabajoAPI.Entities;
using BolsaDeTrabajoAPI.Models;

namespace BolsaDeTrabajoAPI.Services.Interfaces
{
    public interface IPostulationServices
    {
        PostulationDto CreatePostulation(PostulationToCreateDto postulationToCreateDto);
        PostulationDto? GetPostulation(int id);
        List<JobOffer> GetStudentPostulations(string studentId);
        List<Postulation> GetJobOfferPostulations(int jobOfferId);

        public bool CanPostulate(PostulationToCreateDto postulationToCreateDto);
    }
}
