using BolsaDeTrabajoAPI.Data.Interfaces;
using BolsaDeTrabajoAPI.DBContexts;
using BolsaDeTrabajoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeTrabajoAPI.Data;
public class CareerRepository : ICareerRepository
{
    private readonly BDTContext _context;
    public CareerRepository(BDTContext context)
    {
        _context = context;
    }

    public Career? GetCareer(int careerId)
    {
        return _context.Careers.FirstOrDefault(p => p.CareerId == careerId);
    }

    public IEnumerable<Career> GetCareers()
    {
        return _context.Careers.OrderBy(x => x.CareerId).ToList(); ;
    }

    public void DeleteCareer(int careerId)
    {
        var career = _context.Careers.Find(careerId);
        if (career != null)
            _context.Careers.Remove(career);
    }

    public void AddCareer(Career newCareer)
    {
        _context.Careers.Add(newCareer);
    }

    public bool SaveChange()
    {
        return (_context.SaveChanges() >= 0);
    }

    public void UpdateCareer(Career career)
    {
        _context.Entry(career).State = EntityState.Modified;
    }

}

