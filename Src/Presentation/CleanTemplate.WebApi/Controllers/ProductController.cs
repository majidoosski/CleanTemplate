using AutoMapper;
using CleanTemplate.Application.Common.AppSettings;
using CleanTemplate.Application.Contracts.ApplicationContracts;
using CleanTemplate.Application.Contracts.Repositories;
using CleanTemplate.Application.DTOs.Product;
using CleanTemplate.Application.Services.Product;
using CleanTemplate.Application.Views.Product;
using CleanTemplate.Application.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {

        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// Get Product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ApplicationResponse<List<ProductView>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var response = await _productService.GetAsync();
            return Ok(response);
        }

        /// <summary>
        ///  Creat product
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = AppRoles.SuperAdminRoleName)]
        [ProducesResponseType(typeof(ApplicationResponse<long>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] ProductDTO productDTO, CancellationToken cancellationToken)
        {
            var response = await _productService.CreateAsync(productDTO, cancellationToken);
            if (response.Succeeded == false)
                return BadRequest(response);
            return Ok(response);
        }


    }
}
