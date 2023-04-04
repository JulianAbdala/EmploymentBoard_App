using AutoMapper;
using BolsaDeTrabajoAPI.Data.Interfaces;
using BolsaDeTrabajoAPI.Entities;
using BolsaDeTrabajoAPI.Models;
using BolsaDeTrabajoAPI.Services.Interfaces;

namespace BolsaDeTrabajoAPI.Services.Implementations
{
    public class CareerServices : ICareerServices
    {
        private readonly ICareerRepository _careerRepository;
        private readonly IMapper _mapper;

        public CareerServices(IMapper mapper, ICareerRepository careersRepository)
        {
            _careerRepository = careersRepository;
            _mapper = mapper;
        }

        public IEnumerable<CareerDto> GetCareers()
        {
            var careers = _careerRepository.GetCareers();
            return _mapper.Map<IEnumerable<CareerDto>>(careers);
        }

        public CareerDto? GetCareer(int id)
        {
            var career = _careerRepository.GetCareer(id);
            return _mapper.Map<CareerDto?>(career);
        }

        public CareerDto CreateCareer(CareerToCreateDto careerToCreateDto)
        {
            var newCareer = _mapper.Map<Career>(careerToCreateDto);
            _careerRepository.AddCareer(newCareer);
            _careerRepository.SaveChange();

            return _mapper.Map<CareerDto>(newCareer);
        }

        public void DeleteCareer(int careerId)
        {
            _careerRepository.DeleteCareer(careerId);
            _careerRepository.SaveChange();
        }

        public void UpdateCareer(CareerToUpdateDto careerToUpdateDto, int id)
        {
            var careerToUpdate = _careerRepository.GetCareer(id);

            _mapper.Map(careerToUpdateDto, careerToUpdate);

            _careerRepository.UpdateCareer(careerToUpdate);
            _careerRepository.SaveChange();
        }

    }
}
