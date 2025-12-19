using CleanTemplate.Application.Common.AppSettings;
using CleanTemplate.Application.Contracts;
using CleanTemplate.Application.DTOs.Authentication;
using CleanTemplate.Application.Wrappers;
using CleanTemplate.Persistence.Helpers;
using CleanTemplate.Persistence.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Persistence.Identity.Services;

public class AuthenticationServices : IAuthenticationRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtSetiing _jwtSetiing;

    public AuthenticationServices(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IOptionsSnapshot<JwtSetiing> jwtSetting
        )
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _jwtSetiing = jwtSetting.Value;
    }

    public async Task<ApplicationResponse<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
    {

        var user = await _userManager.FindByNameAsync(request.UserName);
        if (user == null)
        {
            throw new Exception("user not defined");
        }
        var result = await _signInManager.PasswordSignInAsync(user, request.PassWord, false, false);
        if (!result.Succeeded)
        {
            throw new Exception($"Invalid Credentials for '{request.UserName}'.");
        }
        string ipAddress=IpHelper.GetIpAddress();

        JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
        RefreshToken refreshToken = GenerateRefreshToken(ipAddress);
        
        var roleList= await _userManager.GetRolesAsync(user);

        var response = new AuthenticationResponse();
        response.JwtToken=new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        response.RefreshToken = refreshToken.Token;
        response.UserName = request.UserName;
        response.Roles = roleList.ToList();


        return new ApplicationResponse<AuthenticationResponse>(response , $"{response.UserName} is authenticate");

    }

    private string RandomTokenString()
    {
        using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
        var randomBytes = new byte[40];
        rngCryptoServiceProvider.GetBytes(randomBytes);
        // convert random bytes to hex string
        return BitConverter.ToString(randomBytes).Replace("-", "");
    }

    private RefreshToken GenerateRefreshToken(string ipAddress)
    {
        return new RefreshToken
        {
            Token = RandomTokenString(),
            Expires = DateTime.UtcNow.AddDays(7),
            Created = DateTime.UtcNow,
            CreatedByIp = ipAddress
        };
    }

    public Task<ApplicationResponse<string>> RegisterAsync(RegisterRequest request, string origin)
    {
        throw new NotImplementedException();
    }
    private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
    {


        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, user.UserName ?? ""),
            new Claim("UserId", user.Id.ToString())
        };

        var roles = await _userManager.GetRolesAsync(user);

        foreach (var userRole in roles)
        {
            claims.Add(new Claim("roles", userRole));

            var role = await _roleManager.FindByNameAsync(userRole);

            if(role == null)
                continue;

            var roleClaims=await _roleManager.GetClaimsAsync(role);

            foreach (var roleClaim in roleClaims)
            {
                claims.Add(roleClaim);
            }

        }
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetiing.AccessTokenKey));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSetiing.Issuer,
                audience: _jwtSetiing.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSetiing.AccessTokenExpirationMinutes),
                signingCredentials: signingCredentials);
        return jwtSecurityToken;


        //claims.AddRange(userClaims.Select(userClaim => new Claim(ClaimTypes.UserData, userClaim)));

    }
}
