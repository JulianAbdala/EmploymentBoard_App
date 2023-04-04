using BolsaDeTrabajoAPI.Entities;

namespace BolsaDeTrabajoAPI.Data.Interfaces
{
    public interface ICareerRepository
    {
        public IEnumerable<Career> GetCareers();
        public Career? GetCareer(int idCareer);
        public void AddCareer(Career career);
        public void DeleteCareer(int careerId);
        public void UpdateCareer(Career career);
        public bool SaveChange();
    }
}
