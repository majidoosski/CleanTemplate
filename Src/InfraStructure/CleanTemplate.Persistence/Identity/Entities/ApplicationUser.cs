using Microsoft.AspNetCore.Identity;

namespace CleanTemplate.Persistence.Identity.Entities;

public class ApplicationUser:IdentityUser<int>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

}
