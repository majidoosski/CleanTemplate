using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.DTOs.Product;
public class ProductDTO:BaseDTO
{
    public decimal? Price { get; set; }
    public int Count { get; set; }
    public string SerialNumber { get; set; }
    public string ImagePath { get; set; }
    public string Type { get; set; }
}
