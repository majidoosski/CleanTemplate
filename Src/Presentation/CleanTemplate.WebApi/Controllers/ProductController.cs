using CleanTemplate.Application.Common.AppSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace CleanTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController: ControllerBase
    {
        [HttpGet]
        [Authorize(Roles =AppRoles.DefaultRoleName)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {

            return Ok();
        }

        //[Authorize(policy: "Manager")]


    }
}
