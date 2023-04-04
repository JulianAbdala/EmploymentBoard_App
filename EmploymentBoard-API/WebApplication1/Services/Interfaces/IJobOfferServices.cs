using BolsaDeTrabajoAPI.Models;

namespace BolsaDeTrabajoAPI.Services.Interfaces
{
    public interface IJobOfferServices
    {
        IEnumerable<JobOfferDto> GetJobOffers();
        JobOfferDto? GetJobOffer(int id);
        IEnumerable<JobOfferDto> GetMyJobOffers(string id);
        JobOfferDto CreateJobOffer(JobOfferToCreateDto jobOfferToCreateDto);
        public void DeleteJobOffer(int id);
        public void UpdateJobOffer(JobOfferToCreateDto jobOfferToUpdateDto, int id);
    }
}
