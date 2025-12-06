using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.Common.AppSettings;

public class AppRoles
{
    public const string AdminRoleName = nameof(RoleNames.Admin);
    public const string SuperAdminRoleName = nameof(RoleNames.SuperAdmin);
    public const string DefaultRoleName = nameof(RoleNames.Default);


}

public enum RoleNames
{
    SuperAdmin = 1,
    Admin = 2,
    Default = 3
}
