using CleanTemplate.Application.Contracts.Repositories;
using CleanTemplate.Domain.Entities;
using CleanTemplate.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Repositories.Services;

public class ProductService:ApplicationService<Product , long> ,IProductRepository
{
    public ProductService(ApplicationContext applicationContext):base(applicationContext)
    {
    }
}
