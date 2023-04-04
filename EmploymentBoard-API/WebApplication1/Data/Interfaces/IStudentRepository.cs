using BolsaDeTrabajoAPI.Entities;

namespace BolsaDeTrabajoAPI.Data.Interfaces
{
    public interface IStudentRepository
    {
        public bool SaveChange();
        void UpdateStudent(Student student);
        public Student? GetStudent(string idStudent);
        public Student? GetStudentByEmail(string email);
        public IEnumerable<Student> GetStudents();
    }
}
