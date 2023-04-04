using AutoMapper;
using BolsaDeTrabajoAPI.Entities;
using BolsaDeTrabajoAPI.Enums;
using BolsaDeTrabajoAPI.Mailing;
using BolsaDeTrabajoAPI.Models;
using BolsaDeTrabajoAPI.Models.Enterprise;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BolsaDeTrabajoAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/enterprises")]
    public class EnterpriseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly UserManager<Enterprise> _userManagerEnterprise;
        private readonly IConfiguration _config;

        public EnterpriseController(UserManager<User> userManager, UserManager<Enterprise> usermanagerEnterprise, IConfiguration config, IMapper mapper)
        {
            _userManager = userManager;
            _userManagerEnterprise = usermanagerEnterprise;
            _config = config;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<EnterpriseDto>> RegisterEnterprise(EnterpriseRegistrationDto enterprise)
        {
            var newEnterprise = new Enterprise()
            {
                Email = enterprise.Email,
                Field = enterprise.Field,
                Cuit = enterprise.Cuit,
                UserName = enterprise.Cuit,
                Location = enterprise.Location,
                AccountStatus = AccountStatusTypes.Pending,
                Name = enterprise.Name,
                FirstName = enterprise.Name,
                LastName = enterprise.Location,
            };

            var result = await _userManager.CreateAsync(newEnterprise, enterprise.Password);
            if (result.Succeeded)
            {
                _ = _userManager.AddToRoleAsync(newEnterprise, "Enterprise");
                Mail oMail = new Mail("bolsadetrabajoutnfrro@gmail.com", enterprise.Email,
                                    $"Estimado/s, Gracias por registrarse en la Bolsa de Trabajo de la UTN. " +
                                    $"Se le notificara nuevamente luego de ser aprobada su solicitud.", "Registro de Empresa // Bolsa de Trabajo UTN");

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

        [HttpGet("getPendingEnterprises")]
        public async Task<ActionResult<IEnumerable<GetPendingEnterprisesDto>>> GetPendingEnterprisesAsync()
        {
            var pendingEnterprises = _userManagerEnterprise.Users.Where(x => x.AccountStatus == AccountStatusTypes.Pending);

            if (pendingEnterprises is null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<GetPendingEnterprisesDto>>(pendingEnterprises));
        }

        [HttpGet("enterprise")]
        public async Task<IActionResult> GetEnterpriseInfo()
        {
            var enterpriseEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            Enterprise enterprise = await _userManagerEnterprise.FindByEmailAsync(enterpriseEmail);

            if (enterprise is null)
                return NotFound();

            return Ok(_mapper.Map<GetEnterpriseProfileInfoDto>(enterprise));
        }

        [HttpPut("updateProfile")]
        public async Task<ActionResult> UpdateProfile(EnterpriseToUpdateDto enterpriseProfile)
        {
            var enterpriseEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            Enterprise enterprise = await _userManagerEnterprise.FindByEmailAsync(enterpriseEmail);

            if (enterprise is null)
                return NotFound();

            _mapper.Map(enterpriseProfile, enterprise);
            var result = await _userManagerEnterprise.UpdateAsync(enterprise);
            if (result.Succeeded)
            {
                return NoContent();
            }
            return BadRequest(result);
        }
        [HttpPut("updateStatus/{enterpriseId}")]
        public async Task<ActionResult> StatusUpdate(string enterpriseId, EnterpriseStatusUpdateDto enterpriseToUpdate)
        {
            
            Enterprise enterprise = await _userManagerEnterprise.FindByIdAsync(enterpriseId);

            if (enterprise is null)
                return NotFound();

            _mapper.Map(enterpriseToUpdate, enterprise);
            var result = await _userManagerEnterprise.UpdateAsync(enterprise);
            if (result.Succeeded)
            {
                if (enterprise.AccountStatus == AccountStatusTypes.Accepted)
                {
                    Mail oMail = new Mail("bolsadetrabajoutnfrro@gmail.com", enterprise.Email,
                                    $"Estimado/s, Su solicitud de registro ha sido aceptada", "Registro Aceptado // Bolsa de Trabajo UTN");

                    if (oMail.enviaMail())
                    {
                        Console.Write("se envio el mail");

                    }
                    else
                    {
                        Console.Write("no se envio el mail: " + oMail.error);

                    }
                } else if (enterprise.AccountStatus == AccountStatusTypes.Rejected)
                {
                    Mail oMail = new Mail("bolsadetrabajoutnfrro@gmail.com", enterprise.Email,
                                    $"Estimado/s, Su solicitud de registro ha sido rechazada", "Registro Rechazado // Bolsa de Trabajo UTN");

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
    }
}
