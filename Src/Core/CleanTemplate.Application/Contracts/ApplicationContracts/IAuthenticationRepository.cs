using CleanTemplate.Application.DTOs.Authentication;
using CleanTemplate.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.Contracts.ApplicationContracts;

public interface IAuthenticationRepository
{
    public Task<ApplicationResponse<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);
    public Task<ApplicationResponse<string>> RegisterAsync(RegisterRequest request, string origin);

}
