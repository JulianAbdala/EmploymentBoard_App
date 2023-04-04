using BolsaDeTrabajoAPI.Data.Interfaces;
using BolsaDeTrabajoAPI.DBContexts;
using BolsaDeTrabajoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeTrabajoAPI.Data;

public class StudentRepository : IStudentRepository
{
    private readonly BDTContext _context;
    public StudentRepository(BDTContext context)
    {
        _context = context;
    }

    public Student? GetStudent(string idStudent)
    {
        return _context.Students.FirstOrDefault(p => p.Id == idStudent);
    }

    public Student? GetStudentByEmail(string email)
    {
        return _context.Students.FirstOrDefault(p => p.Email == email);
    }

    public IEnumerable<Student> GetStudents()
    {
        return _context.Students.OrderBy(x => x.Id).ToList();
    }

    public void UpdateStudent(Student student)
    {
        _context.Entry(student).State = EntityState.Modified;
    }

    public bool SaveChange()
    {
        return (_context.SaveChanges() >= 0);
    }

    public Student? GetStudent(int idStudent)
    {
        throw new NotImplementedException();
    }
}
