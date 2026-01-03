using AutoMapper;
using CleanTemplate.Application.Contracts.ApplicationContracts;
using CleanTemplate.Application.Contracts.Repositories;
using CleanTemplate.Application.DTOs.Product;
using CleanTemplate.Application.Validations.Product;
using CleanTemplate.Application.Views.Product;
using CleanTemplate.Application.Wrappers;
using CleanTemplate.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace CleanTemplate.Application.Services.Product;

public class ProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<ProductDTO> _validator;
    private readonly ILogger<ProductService> _logger;
    private readonly IUnitOfWorkRepository _unitOfWorkRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper, ILogger<ProductService> logger, IUnitOfWorkRepository unitOfWorkRepository, IValidator<ProductDTO> validator)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _logger = logger;
        _unitOfWorkRepository = unitOfWorkRepository;
        _validator = validator;
    }


    public async Task<ApplicationResponse<List<ProductView>>> GetAsync()
    {

        var result = await _productRepository.GetAll();
        var resultView = _mapper.Map<List<ProductView>>(result);
        var response = new ApplicationResponse<List<ProductView>>(resultView);
        return response;
    }


    public async Task<ApplicationResponse<long>> CreateAsync(ProductDTO productDTO, CancellationToken cancellationToken)
    {

        ApplicationResponse<long> applicationResponse = new ApplicationResponse<long>();
        //first validate dto
        var validationResult = await _validator.ValidateAsync(productDTO, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("ProductDTO validation failed {@ProductDTO} with errors {@Errors}", productDTO, validationResult.Errors.Select(e => e.ErrorMessage));
            applicationResponse.Succeeded = false;
            foreach (var error in validationResult.Errors)
            {
                applicationResponse.Errors.Add(error.ErrorMessage);
            }
            applicationResponse.Message = "request model is not valid.";

            return applicationResponse;
        }
        try
        {
            var entity = _mapper.Map<Domain.Entities.Product>(productDTO);
            await _productRepository.Create(entity);
            await _unitOfWorkRepository.CommitAsync(cancellationToken);

            _logger.LogInformation("product creation is done");

            applicationResponse.Succeeded =true;
            applicationResponse.Data = entity.Id;
            applicationResponse.Message = $"product created at {DateTime.Now}";


            return applicationResponse;

        }
        catch (Exception ex)
        {

            _logger.LogError(ex,"Product creation failed for DTO {@ProductDTO} at {Time}",productDTO,DateTime.UtcNow);

            applicationResponse.Succeeded = false;
            applicationResponse.Message = "An unexpected error occurred while creating the product";
            return applicationResponse;
        }




    }

}
