using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanTemplate.Domain.Entities;

[Table("ApplicationPermissions", Schema = "SEC")]
public class ApplicationPermissions
{
    [Key]
    public int Id { get; set; }

    [Required]
    public  string Title { get; set; }
}
