using AutoMapper;
using CleanTemplate.Application.Contracts.ApplicationContracts;
using CleanTemplate.Application.Contracts.Repositories;
using CleanTemplate.Application.Views.Product;
using CleanTemplate.Application.Wrappers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.Services.Product;

public class ProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductService> _logger;
    private readonly IUnitOfWorkRepository _unitOfWorkRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper, ILogger<ProductService> logger, IUnitOfWorkRepository unitOfWorkRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _logger = logger;
        _unitOfWorkRepository = unitOfWorkRepository;
    }


    public async Task<ApplicationResponse<List<ProductView>>> GetAsync()
    {
        var result = await _productRepository.GetAll();
        var resultView = _mapper.Map<List<ProductView>>(result);
        var response = new ApplicationResponse<List<ProductView>>(resultView);
        return response;
    }

}
