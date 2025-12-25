using CleanTemplate.Application.Contracts.ApplicationContracts;
using CleanTemplate.Application.Views.Product;
using CleanTemplate.Application.Wrappers;
using CleanTemplate.Domain.Entities;
namespace CleanTemplate.Application.Contracts.Repositories;

public interface IProductRepository : IApplicationRepository<Product, long>
{

    
}
