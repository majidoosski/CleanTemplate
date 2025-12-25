using CleanTemplate.Application.Contracts.ApplicationContracts;
using CleanTemplate.Application.DTOs.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanTemplate.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }



        /// <summary>
        ///the enpoint that authenticate user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Authenicate")]
        [AllowAnonymous]
        
        public async Task<IActionResult> Authenticate(AuthenticationRequest request) 
        {
            return Ok(await _authenticationRepository.AuthenticateAsync(request));  
        }
    }
}
