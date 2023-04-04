using BolsaDeTrabajoAPI.Models;

namespace BolsaDeTrabajoAPI.Services.Interfaces
{
    public interface IStudentServices
    {
        IEnumerable<StudentDto> GetStudents();
        IEnumerable<JobOfferDto> GetMyPostulations(string studentId);
    }
}
