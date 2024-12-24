using Microsoft.AspNetCore.Identity;

namespace EduTrail.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public bool IsValidUser()
    {
        // TODO: email regex
        return !string.IsNullOrWhiteSpace(UserName)
               && UserName.Length >= 3
               && !string.IsNullOrWhiteSpace(Email)
               && Email.Contains('@');
    }
}
