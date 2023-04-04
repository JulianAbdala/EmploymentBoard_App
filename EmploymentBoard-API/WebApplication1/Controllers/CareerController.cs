using AutoMapper;
using BolsaDeTrabajoAPI.Data.Interfaces;
using BolsaDeTrabajoAPI.Models;
using BolsaDeTrabajoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BolsaDeTrabajoAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/careers")]
    public class CareerController : ControllerBase
    {
        private readonly ICareerServices _careerServices;
        private readonly IMapper _mapper;
        public CareerController(ICareerServices careerServices, ICareerRepository careerRepository, IMapper mapper)
        {
            _careerServices = careerServices;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CareerDto>> GetCareers()
        {
            var careers = _careerServices.GetCareers();
            return Ok(careers);
        }

        [HttpGet("{id}", Name = "GetCareer")]
        public IActionResult GetProduct(int id)

        {
            var career = _careerServices.GetCareer(id);
            if (career == null)
                return NotFound();

            return Ok(_mapper.Map<CareerDto>(career));
        }


        [HttpPost]
        public IActionResult CreateCareer(CareerToCreateDto newCareer)

        {
            var createdCareer = _careerServices.CreateCareer(newCareer);

            return CreatedAtRoute(
                "GetCareer",
                new
                {
                    id = createdCareer.CareerId
                },
                createdCareer);

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCareer(int id)
        {

            _careerServices.DeleteCareer(id);

            return NoContent();
        }

        [HttpPut("{careerId}")]
        public ActionResult UpdateCareer(CareerToUpdateDto careerToUpdate, int careerId)
        {
            _careerServices.UpdateCareer(careerToUpdate, careerId);

            return NoContent();
        }
    }
}

