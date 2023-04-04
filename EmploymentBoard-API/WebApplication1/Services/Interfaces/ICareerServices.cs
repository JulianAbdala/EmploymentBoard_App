using BolsaDeTrabajoAPI.Models;

namespace BolsaDeTrabajoAPI.Services.Interfaces
{
    public interface ICareerServices
    {
        IEnumerable<CareerDto> GetCareers();
        CareerDto? GetCareer(int id);
        CareerDto CreateCareer(CareerToCreateDto careerToCreateDto);
        public void DeleteCareer(int id);
        public void UpdateCareer(CareerToUpdateDto careerToUpdateDto, int id);
    }
}
