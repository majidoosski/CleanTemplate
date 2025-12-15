using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Helpers;

public static class UserHelper
{

    public static int? GetUserID(this ClaimsPrincipal principal)
    {
        if (principal is null)
            throw new ArgumentNullException(nameof(principal));

        string? id = principal.FindFirstValue("UserId") ?? principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? principal.FindFirstValue(JwtRegisteredClaimNames.Sub);

        if (int.TryParse(id, out int UserId))
            return UserId;

        return null;

    }
}
