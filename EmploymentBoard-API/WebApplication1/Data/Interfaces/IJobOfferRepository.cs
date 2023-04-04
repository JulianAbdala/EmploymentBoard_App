using BolsaDeTrabajoAPI.Entities;

namespace BolsaDeTrabajoAPI.Data.Interfaces
{
    public interface IJobOfferRepository
    {
        public IEnumerable<JobOffer> GetJobOffers();
        public JobOffer? GetJobOffer(int jobOfferId);
        public IEnumerable<JobOffer> GetMyJobOffers(string enterpriseId);
        public void AddJobOffer(JobOffer jobOffer);
        public void DeleteJobOffer(int jobOfferId);
        public void UpdateJobOffer(JobOffer jobOffer);
        public bool SaveChange();
    }
}
