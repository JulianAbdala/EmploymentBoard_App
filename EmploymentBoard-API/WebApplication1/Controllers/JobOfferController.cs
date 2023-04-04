using AutoMapper;
using BolsaDeTrabajoAPI.Data.Interfaces;
using BolsaDeTrabajoAPI.Entities;
using BolsaDeTrabajoAPI.Models;
using BolsaDeTrabajoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BolsaDeTrabajoAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/jobOffers")]
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOfferServices _jobOfferServices;
        private readonly UserManager<Enterprise> _userManagerEnterprise;
        private readonly IMapper _mapper;
        public JobOfferController(UserManager<Enterprise> userManagerEnterprise, IJobOfferServices jobOfferServices, IMapper mapper)
        {
            _userManagerEnterprise = userManagerEnterprise;
            _jobOfferServices = jobOfferServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<JobOfferDto>> GetJobOffers()
        {
            var jobOffers = _jobOfferServices.GetJobOffers();

            return Ok(jobOffers);
        }

        [HttpGet("{id}", Name = "GetJobOffer")]
        public IActionResult GetJobOffer(int id)

        {
            var jobOffer = _jobOfferServices.GetJobOffer(id);
            if (jobOffer == null)
                return NotFound();

            return Ok(_mapper.Map<JobOfferDto>(jobOffer));
        }

        [HttpGet("enterpriseId")]
        public IActionResult GetMyJobOffers(string id)
        {
            var jobOffers = _jobOfferServices.GetMyJobOffers(id);
            // Agregar las postulaciones
            return Ok(jobOffers);
        }


        [HttpPost]
        public async Task<ActionResult> CreateJobOffer(JobOfferToCreateDto newJobOffer)

        {
            var createdJobOffer = _jobOfferServices.CreateJobOffer(newJobOffer);

            return CreatedAtRoute(
                "GetJobOffer",
                new
                {
                    id = createdJobOffer.Id
                },
                createdJobOffer);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteJobOffer(int id)
        {
            _jobOfferServices.DeleteJobOffer(id);

            return NoContent();
        }

        [HttpPut]
        public ActionResult UpdateJobOffer(JobOfferToCreateDto jobOfferToUpdate, int jobOfferId)
        {
            _jobOfferServices.UpdateJobOffer(jobOfferToUpdate, jobOfferId);

            return NoContent();
        }
    }
}

