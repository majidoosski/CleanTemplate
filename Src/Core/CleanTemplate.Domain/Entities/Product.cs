using CleanTemplate.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanTemplate.Domain.Entities;


[Table("Product", Schema = "App")]
public class Product : BaseEntity<long>
{
    [Description("")]
    [Required]
    public decimal Price { get; set; }

    [Description("")]
    [Required]
    public int Count { get; set; }

    [MaxLength(100)]
    public string? SerialNumber { get; set; }
    public string? ImagePath { get; set; }
    public string? Type { get; set; }
}

