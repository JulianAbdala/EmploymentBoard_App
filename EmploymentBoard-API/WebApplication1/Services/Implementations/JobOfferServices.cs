using AutoMapper;
using BolsaDeTrabajoAPI.Data.Interfaces;
using BolsaDeTrabajoAPI.Entities;
using BolsaDeTrabajoAPI.Models;
using BolsaDeTrabajoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BolsaDeTrabajoAPI.Services.Implementations
{
    public class JobOfferServices : IJobOfferServices
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IMapper _mapper;

        public JobOfferServices(IMapper mapper, IJobOfferRepository jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
        }

        public IEnumerable<JobOfferDto> GetJobOffers()
        {
            var jobOffers = _jobOfferRepository.GetJobOffers();
            return _mapper.Map<IEnumerable<JobOfferDto>>(jobOffers);
        }

        public JobOfferDto? GetJobOffer(int id)
        {
            var jobOffer = _jobOfferRepository.GetJobOffer(id);
            return _mapper.Map<JobOfferDto?>(jobOffer);
        }

        public IEnumerable<JobOfferDto> GetMyJobOffers(string id)
        {
            var jobOffers = _jobOfferRepository.GetMyJobOffers(id);
            return _mapper.Map<IEnumerable<JobOfferDto>>(jobOffers);
        }

        public JobOfferDto CreateJobOffer(JobOfferToCreateDto jobOfferToCreateDto)
        {
            var newJobOffer = _mapper.Map<JobOffer>(jobOfferToCreateDto);
            _jobOfferRepository.AddJobOffer(newJobOffer);
            _jobOfferRepository.SaveChange();

            return _mapper.Map<JobOfferDto>(newJobOffer);
        }

        public void DeleteJobOffer(int jobOfferId)
        {
            _jobOfferRepository.DeleteJobOffer(jobOfferId);
            _jobOfferRepository.SaveChange();
        }

        public void UpdateJobOffer(JobOfferToCreateDto jobOfferToUpdateDto, int id)
        {
            var jobOfferToUpdate = _jobOfferRepository.GetJobOffer(id);

            _mapper.Map(jobOfferToUpdateDto, jobOfferToUpdate);

            _jobOfferRepository.UpdateJobOffer(jobOfferToUpdate);
            _jobOfferRepository.SaveChange();
        }

    }
}
