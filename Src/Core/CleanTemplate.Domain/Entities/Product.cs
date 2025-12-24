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
    public decimal? Price { get; set; }
    
    [Description("")]
    public int Count { get; set; }
    [Required]
    [MaxLength(100)]
    public string SerialNumber { get; set; }
    [AllowNull]
    public string ImagePath { get; set; }
    [Required]
    public string  Type { get; set; }
}

