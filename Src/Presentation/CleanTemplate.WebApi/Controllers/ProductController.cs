using AutoMapper;
using CleanTemplate.Application.Common.AppSettings;
using CleanTemplate.Application.Contracts.ApplicationContracts;
using CleanTemplate.Application.Contracts.Repositories;
using CleanTemplate.Application.DTOs.Product;
using CleanTemplate.Application.Views.Product;
using CleanTemplate.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository ;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public ProductController(IMapper mapper, IProductRepository productRepository, IUnitOfWorkRepository unitOfWorkRepository, ILogger<ProductController> logger)
        {
            _mapper =mapper ;
            _productRepository = productRepository;
            _unitOfWorkRepository = unitOfWorkRepository;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ProductView>>> Get(CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetAll();
            return Ok(_mapper.Map<List<ProductView>>(result));
        }

        //[Authorize(policy: "Manager")]


    }
}
