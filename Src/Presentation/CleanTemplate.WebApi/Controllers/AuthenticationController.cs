using CleanTemplate.Application.Contracts;
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
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
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
            return Ok(await _authenticationService.AuthenticateAsync(request));  
        }
    }
}
