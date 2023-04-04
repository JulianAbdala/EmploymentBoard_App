using AutoMapper;
using BolsaDeTrabajoAPI.Entities;
using BolsaDeTrabajoAPI.Models;
using BolsaDeTrabajoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BolsaDeTrabajoAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/postulation")]
    public class PostulationController : ControllerBase
    {
        private readonly IPostulationServices _postulationServices;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public PostulationController(UserManager<User> userManager, IPostulationServices postulationServices, IMapper mapper)
        {
            _userManager = userManager;
            _postulationServices = postulationServices;
            _mapper = mapper;
        }

        [HttpPost("studentPostulation")]
        public async Task<ActionResult> CreatePostulation(PostulationToCreateDto newPostulation)

        {
            if (_postulationServices.CanPostulate(newPostulation))
            {
                var createdPostulation = _postulationServices.CreatePostulation(newPostulation);
                return CreatedAtRoute(
                  "GetPostulation",
                  new
                  {
                      id = createdPostulation.Id
                  },
                  createdPostulation);
            }
            else
            {
                return BadRequest();
            }


        }

        [HttpGet("{id}", Name = "GetPostulation")]
        public IActionResult GetPostulation(int id)

        {
            var postulation = _postulationServices.GetPostulation(id);
            if (postulation == null)
                return NotFound();

            return Ok(_mapper.Map<PostulationDto>(postulation));
        }

        [HttpGet("jobOfferId")]
        public IActionResult GetJobOfferPostulations(int id)
        {
            var postulations = _postulationServices.GetJobOfferPostulations(id);
            if (postulations == null)
                return NotFound();
            return Ok(postulations);
        }
    }

    
}
