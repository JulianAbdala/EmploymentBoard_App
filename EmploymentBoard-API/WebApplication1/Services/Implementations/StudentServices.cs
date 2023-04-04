using AutoMapper;
using BolsaDeTrabajoAPI.Data.Interfaces;
using BolsaDeTrabajoAPI.Entities;
using BolsaDeTrabajoAPI.Models;
using BolsaDeTrabajoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BolsaDeTrabajoAPI.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IPostulationRepository _postulationRepository;
        private readonly IJobOfferServices _jobOfferServices;

        public StudentServices(IMapper mapper, IStudentRepository studentsRepository, UserManager<User> userManager, IPostulationRepository postulationRepository, IJobOfferServices jobOfferServices)
        {
            _studentRepository = studentsRepository;
            _mapper = mapper;
            _userManager = userManager;
            _postulationRepository = postulationRepository;
            _jobOfferServices = jobOfferServices;
        }

        public IEnumerable<StudentDto> GetStudents()
        {
            var students = _studentRepository.GetStudents();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public IEnumerable<JobOfferDto> GetMyPostulations(string studentId)
        {
            var jobOffers = _postulationRepository.GetStudentPostulations(studentId);
            return _mapper.Map<IEnumerable<JobOfferDto>>(jobOffers);
        }

    }
}
