using AutoMapper;
using BolsaDeTrabajoAPI.Models;

namespace BolsaDeTrabajoAPI.Profiles
{
    public class JobOfferProfile : Profile
    {
        public JobOfferProfile()
        {
            CreateMap<Entities.JobOffer, JobOfferDto>();
            CreateMap<JobOfferDto, Entities.JobOffer>();
            CreateMap<JobOfferToCreateDto, Entities.JobOffer>();
            CreateMap<Entities.JobOffer, JobOfferToCreateDto>();
        }
    }
}
