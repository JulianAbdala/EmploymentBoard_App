using AutoMapper;
using BolsaDeTrabajoAPI.Data.Interfaces;
using BolsaDeTrabajoAPI.Entities;
using BolsaDeTrabajoAPI.Models;
using BolsaDeTrabajoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BolsaDeTrabajoAPI.Services.Implementations
{
    public class PostulationServices : IPostulationServices
    {
        private readonly IPostulationRepository _postulationRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public PostulationServices(IMapper mapper, IPostulationRepository postulationRepository, UserManager<User> userManager)
        {
            _postulationRepository = postulationRepository;
            _userManager = userManager;
            _mapper = mapper;
        }
        public PostulationDto? GetPostulation(int id)
        {
            var postulation = _postulationRepository.GetPostulation(id);
            return _mapper.Map<PostulationDto?>(postulation);
        }

        public IEnumerable<PostulationDto> GetPostulations()
        {
            var postulations = _postulationRepository.GetPostulations();
            return _mapper.Map<IEnumerable<PostulationDto>>(postulations);
        }

        public List<JobOffer> GetStudentPostulations(string studentId)
        {
            return _postulationRepository.GetStudentPostulations(studentId);
        }
        public PostulationDto CreatePostulation(PostulationToCreateDto postulationToCreateDto)
        {
            var newPostulation = _mapper.Map<Postulation>(postulationToCreateDto);
            _postulationRepository.AddPostulation(newPostulation);
            _postulationRepository.SaveChange();
            return _mapper.Map<PostulationDto>(newPostulation);
        }

        public List<Postulation> GetJobOfferPostulations(int jobOfferId)
        {
            return _postulationRepository.GetJobOfferPostulations(jobOfferId);
        }

        public bool CanPostulate(PostulationToCreateDto postulationToCreateDto)
        {
            return _postulationRepository.CanPostulate(postulationToCreateDto);
        }
    }
}
