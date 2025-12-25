using CleanTemplate.Application.Contracts.ApplicationContracts;
using CleanTemplate.Persistence.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Repositories.InfraServices;

public class CurrnetUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrnetUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public int? GetUserId()
    {
       return  _httpContextAccessor.HttpContext?.User.GetUserID();

    }
}
