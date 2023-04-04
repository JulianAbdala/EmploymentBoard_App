using AutoMapper;
using BolsaDeTrabajoAPI.Models;

namespace BolsaDeTrabajoAPI.Profiles
{
    public class CareerProfile : Profile
    {
        public CareerProfile()
        {
            CreateMap<Entities.Career, CareerDto>();
            CreateMap<CareerDto, Entities.Career>();
            CreateMap<CareerToCreateDto, Entities.Career>();
            CreateMap<CareerToUpdateDto, Entities.Career>();
            CreateMap<Entities.Career, CareerToUpdateDto>();
        }
    }
}
