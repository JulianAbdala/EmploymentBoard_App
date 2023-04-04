using AutoMapper;
using BolsaDeTrabajoAPI.Models.Skills;
using BolsaDeTrabajoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BolsaDeTrabajoAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/studentSkills")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillServices _skillServices;
        private readonly IMapper _mapper;

        public SkillController(ISkillServices skillServices, IMapper mapper)
        {
            _skillServices = skillServices;
            _mapper = mapper;
        }

        [HttpGet("getMySkills")]
        public IEnumerable<SkillDto> GetMySkills(string studentId)
        {
            return _skillServices.GetMySkills(studentId);

        }

    }

}
