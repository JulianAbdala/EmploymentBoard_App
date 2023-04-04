using AutoMapper;
using BolsaDeTrabajoAPI.Entities;
using BolsaDeTrabajoAPI.Enums;
using BolsaDeTrabajoAPI.Mailing;
using BolsaDeTrabajoAPI.Models;
using BolsaDeTrabajoAPI.Models.Student;
using BolsaDeTrabajoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BolsaDeTrabajoAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IPostulationServices _postulationServices;
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly UserManager<Student> _userManagerStudent;
        private readonly IConfiguration _config;

        public StudentController(UserManager<User> userManager, UserManager<Student> userManagerStudent, IConfiguration config, IMapper mapper, IPostulationServices postulationServices, IStudentServices studentServices)
        {
            _userManager = userManager;
            _userManagerStudent = userManagerStudent;
            _postulationServices = postulationServices;
            _studentServices = studentServices;
            _config = config;
            _mapper = mapper;
        }

        [HttpGet("student")]
        public async Task<IActionResult> GetStudentInfo()
        {
            var studentEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            Student student = (Student)await _userManager.FindByEmailAsync(studentEmail);

            if (student is null)
                return NotFound();

            return Ok(_mapper.Map<GetStudentProfileInfo>(student));
        }

        [HttpGet("getPendingStudents")]
        public async Task<ActionResult<IEnumerable<GetPendingStudentsDto>>> GetPendingStudentsAsync()
        {
            var pendingStudents = _userManagerStudent.Users.Where(x => x.AccountStatus == AccountStatusTypes.Pending);

            if (pendingStudents is null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<GetPendingStudentsDto>>(pendingStudents));
        }


        [HttpPut("updateProfile")]
        public async Task<ActionResult> UpdateProfile(StudentToUpdateDto studentProfile)
        {
            var studentEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            Student student = (Student)await _userManager.FindByEmailAsync(studentEmail);

            if (student is null)
                return NotFound();

            _mapper.Map(studentProfile, student);
            var result = await _userManager.UpdateAsync(student);
            if (result.Succeeded)
            {
                return NoContent();
            }
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<StudentDto>> RegisterStudent(StudentRegistrationDto student)
        {
            var newStudent = new Student()
            {
                UserName = student.FileNumber + student.Email,
                Email = student.Email,
                FileNumber = student.FileNumber,
                AccountStatus = AccountStatusTypes.Pending,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Name = student.Email,
            };

            var result = await _userManager.CreateAsync(newStudent, student.Password);
            if (result.Succeeded)
            {
                _ = _userManager.AddToRoleAsync(newStudent, "Student");
                Mail oMail = new Mail("bolsadetrabajoutnfrro@gmail.com", student.Email,
                                    $"Estimado {student.FirstName} {student.LastName}, Gracias por registrarse en la Bolsa de Trabajo de la UTN. " +
                                    $"Se le notificara nuevamente luego de ser aprobada su solicitud.", "Registro de Alumno // Bolsa de Trabajo UTN");

                if (oMail.enviaMail())
                {
                    Console.Write("se envio el mail");

                }
                else
                {
                    Console.Write("no se envio el mail: " + oMail.error);

                }

                return Ok();
            }
            return BadRequest(result);
        }

        [HttpPost("UploadCV")]
        public async Task<IActionResult> UploadCV([FromForm] UploadCVDto request)
        {
            var student = (Student)await _userManager.FindByIdAsync(request.StudentId);

            if (student is null)
            {
                return BadRequest();
            }

            IFormFile file = request.File;

            long length = file.Length;
            if (length < 0)
                return BadRequest("You should attach a valid pdf file");

            using var fileStream = file.OpenReadStream();
            byte[] bytes = new byte[length];
            fileStream.Read(bytes, 0, (int)file.Length);

            student.Curriculum = bytes;

            await _userManager.UpdateAsync(student);

            return Ok();
        }

        [HttpGet("DownloadCV")]
        public async Task<IActionResult> GetCurriculum(string UserId)
        {
            var student = (Student)await _userManager.FindByIdAsync(UserId);

            if (student is null)
            {
                return NotFound();
            }

            if (student.Curriculum is null)
            {
                return BadRequest();
            }

            return File(student.Curriculum, "application/pdf", $"{student.FirstName}_{student.LastName}_CV.pdf");
        }

        [HttpPut("updateStatus/{studentId}")]
        public async Task<ActionResult> StatusUpdate(string studentId, StudentStatusUpdateDto studentToUpdate)
        {

            Student student = await _userManagerStudent.FindByIdAsync(studentId);

            if (student is null)
                return NotFound();

            _mapper.Map(studentToUpdate, student);
            var result = await _userManagerStudent.UpdateAsync(student);
            if (result.Succeeded)
            {
                if (student.AccountStatus == AccountStatusTypes.Accepted)
                {
                    Mail oMail = new Mail("bolsadetrabajoutnfrro@gmail.com", student.Email,
                                    $"Estimado {student.FirstName} {student.LastName}, Su solicitud de registro ha sido aceptada", "Registro Aceptado // Bolsa de Trabajo UTN");

                    if (oMail.enviaMail())
                    {
                        Console.Write("se envio el mail");

                    }
                    else
                    {
                        Console.Write("no se envio el mail: " + oMail.error);

                    }
                } else if (student.AccountStatus == AccountStatusTypes.Rejected)
                {
                    Mail oMail = new Mail("bolsadetrabajoutnfrro@gmail.com", student.Email,
                                    $"Estimado {student.FirstName} {student.LastName}, Su solicitud de registro ha sido rechazada", "Registro Rechazado // Bolsa de Trabajo UTN");

                    if (oMail.enviaMail())
                    {
                        Console.Write("se envio el mail");

                    }
                    else
                    {
                        Console.Write("no se envio el mail: " + oMail.error);

                    }
                }
                return NoContent();
            }
            return BadRequest(result);
        }

        [HttpGet("getAppliedOffers")]
        public IEnumerable<JobOfferDto> GetMyOffers(string studentId)
        {
            return _studentServices.GetMyPostulations(studentId);

        }
    }
}
