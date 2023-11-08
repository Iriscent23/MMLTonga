using Microsoft.AspNetCore.Identity;

namespace MMLTonga.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }

    }
}
