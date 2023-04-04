using BolsaDeTrabajoAPI.Data.Interfaces;
using BolsaDeTrabajoAPI.DBContexts;
using BolsaDeTrabajoAPI.Entities;
using BolsaDeTrabajoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeTrabajoAPI.Data.Implementations
{
    public class PostulationRepository : IPostulationRepository
    {
        private readonly BDTContext _context;


        public PostulationRepository(BDTContext context)
        {
            _context = context;
        }

        public Postulation? GetPostulation(int postulationId)
        {
            return _context.Postulations.FirstOrDefault(p => p.Id == postulationId);
        }

        public IEnumerable<Postulation> GetPostulations()
        {
            return _context.Postulations.OrderBy(x => x.Id).ToList(); ;
        }
        public void AddPostulation(Postulation newPostulation)
        {
            _context.Postulations.Add(newPostulation);

        }

        public bool CanPostulate(PostulationToCreateDto postulationDto)
        {
            return (!_context.Postulations.Any(x => x.StudentId == postulationDto.StudentId && x.JobOfferId == postulationDto.JobOfferId));
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public List<JobOffer?> GetStudentPostulations(string studentId)
        {
            return _context.Postulations
                .Include(x => x.JobOfferPostulation)
                .Where(p => p.StudentId == studentId)
                .Select(x => x.JobOfferPostulation)
                .ToList();
        }
           
        public List<Postulation> GetJobOfferPostulations(int jobOfferId)
        {
            return _context.Postulations
                .Where(p => p.JobOfferId == jobOfferId)
                .Include(P => P.Student)
                .ToList();
        }
    }
}