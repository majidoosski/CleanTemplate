using CleanTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Identity.Entities;

[Table("ApplicationRolePermissions", Schema ="SEC")]
public class ApplicationRolePermissions
{
    public int Id { get; set; } 

    [ForeignKey("ApplicationPermissions")]
    public int PermissionId{ get; set; }
    public ApplicationPermissions ApplicationPermissions { get; set; }
    [ForeignKey("ApplicationRole")]
    public int RoleId{ get; set; }  
    public ApplicationRole ApplicationRole { get; set; }  
}
