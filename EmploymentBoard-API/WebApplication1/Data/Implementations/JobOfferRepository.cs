using BolsaDeTrabajoAPI.Data.Interfaces;
using BolsaDeTrabajoAPI.DBContexts;
using BolsaDeTrabajoAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeTrabajoAPI.Data;

public class JobOfferRepository : IJobOfferRepository
{
    private readonly BDTContext _context;
    private readonly UserManager<User> _userManager;


    public JobOfferRepository(UserManager<User> userManager, BDTContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public JobOffer? GetJobOffer(int jobOfferId)
    {
        return _context.JobOffers.FirstOrDefault(p => p.Id == jobOfferId);
    }

    public IEnumerable<JobOffer> GetJobOffers()
    {
        return _context.JobOffers.OrderBy(x => x.Id).ToList(); ;
    }

    public IEnumerable<JobOffer> GetMyJobOffers(string enterpriseId)
    {
        return _context.JobOffers.Where(x => x.EnterpriseId == enterpriseId).OrderBy(x => x.Id).ToList(); ;
    }

    public void DeleteJobOffer(int jobOfferId)
    {
        var jobOffer = _context.JobOffers.Find(jobOfferId);
        if (jobOffer != null)
            _context.JobOffers.Remove(jobOffer);
    }

    public void AddJobOffer(JobOffer newJobOffer)
    {
        _context.JobOffers.Add(newJobOffer);
    }

    public bool SaveChange()
    {
        return (_context.SaveChanges() >= 0);
    }

    public void UpdateJobOffer(JobOffer jobOffer)
    {
        _context.Entry(jobOffer).State = EntityState.Modified;
    }

}

