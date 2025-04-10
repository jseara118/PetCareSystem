using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PetCareSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string NombreCompleto { get; set; }

        [Required]
        public string Telefono { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
