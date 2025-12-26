using AutoMapper;
using CleanTemplate.Application.Common.AppSettings;
using CleanTemplate.Application.Contracts.ApplicationContracts;
using CleanTemplate.Application.Contracts.Repositories;
using CleanTemplate.Application.DTOs.Product;
using CleanTemplate.Application.Services;
using CleanTemplate.Application.Views.Product;
using CleanTemplate.Application.Wrappers;
using CleanTemplate.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public ProductController(IMapper mapper, IProductRepository productRepository, IUnitOfWorkRepository unitOfWorkRepository, ILogger<ProductController> logger)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _unitOfWorkRepository = unitOfWorkRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ApplicationResponse<List<ProductView>>>> Get()
        {
            //var service = new GetRequestService<Product, long, ProductView>(_productRepository, _mapper);
            var result= await _productRepository.GetAll();
            var resultView=_mapper.Map<List<ProductView>>(result);
            var response = new ApplicationResponse<List<ProductView>>(resultView);


            return Ok(response);
        }

        //[Authorize(policy: "Manager")]


    }
}
