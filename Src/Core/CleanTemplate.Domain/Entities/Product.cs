using CleanTemplate.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Domain.Entities;


[Table("Product" , Schema ="App")]
public class Product:BaseEntity<long>
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
    public string?  Type { get; set; }
}

