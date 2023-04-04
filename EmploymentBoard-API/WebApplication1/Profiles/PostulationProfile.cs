using AutoMapper;
using BolsaDeTrabajoAPI.Models;

namespace BolsaDeTrabajoAPI.Profiles
{
    public class PostulationProfile : Profile
    {
        public PostulationProfile()
        {
            CreateMap<Entities.Postulation, PostulationDto>();
            CreateMap<PostulationDto, Entities.Postulation>();
            CreateMap<PostulationToCreateDto, Entities.Postulation>();
            CreateMap<Entities.Postulation, PostulationToCreateDto>();
        }
    }
}
