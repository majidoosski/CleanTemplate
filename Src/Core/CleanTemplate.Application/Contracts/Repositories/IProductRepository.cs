using CleanTemplate.Application.Contracts.ApplicationContracts;
using CleanTemplate.Domain.Entities;
namespace CleanTemplate.Application.Contracts.Repositories;

public interface IProductRepository : IApplicationRepository<Product, long>
{


}
