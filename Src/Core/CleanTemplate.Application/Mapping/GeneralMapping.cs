using AutoMapper;
using CleanTemplate.Application.DTOs.Product;
using CleanTemplate.Application.Views.Product;
using CleanTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.Mapping;

public class GeneralMapping:Profile
{
    public GeneralMapping()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Product, ProductView>().ReverseMap();

    }
}
