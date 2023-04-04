using AutoMapper;
using BolsaDeTrabajoAPI.Models;
using BolsaDeTrabajoAPI.Models.Enterprise;

namespace BolsaDeTrabajoAPI.Profiles
{
    public class EnterpriseProfile : Profile
    {
        public EnterpriseProfile()
        {
            CreateMap<Entities.Enterprise, EnterpriseDto>();
            CreateMap<EnterpriseDto, Entities.Enterprise>();
            CreateMap<EnterpriseToUpdateDto, Entities.Enterprise>();
            CreateMap<Entities.Enterprise, EnterpriseToUpdateDto>();
            CreateMap<GetEnterpriseProfileInfoDto, Entities.Enterprise>();
            CreateMap<Entities.Enterprise, GetEnterpriseProfileInfoDto>();
            CreateMap<GetPendingEnterprisesDto, Entities.Enterprise>();
            CreateMap<Entities.Enterprise, GetPendingEnterprisesDto>();
            CreateMap<EnterpriseStatusUpdateDto, Entities.Enterprise>();
            CreateMap<Entities.Enterprise, EnterpriseStatusUpdateDto>();
        }
    }
}
