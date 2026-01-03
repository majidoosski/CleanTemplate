using CleanTemplate.Application.Contracts.Repositories;
using CleanTemplate.Domain.Entities;
using CleanTemplate.Persistence.Context;
using CleanTemplate.Persistence.Repositories.InfraServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Repositories.Services;

public class ProductRepository:ApplicationRepository<Product , long> ,IProductRepository
{
    public ProductRepository(ApplicationContext applicationContext):base(applicationContext)
    {

    }
}
