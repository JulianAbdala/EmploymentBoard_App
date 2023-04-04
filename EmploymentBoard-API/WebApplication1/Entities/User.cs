using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace BolsaDeTrabajoAPI.Entities
{
    public abstract class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
