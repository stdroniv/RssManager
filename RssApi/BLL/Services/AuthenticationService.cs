using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RssApi.BLL.Contracts;
using RssApi.BLL.DTOs;
using RssApi.DAL.Configuration;
using RssApi.DAL.Entities;

namespace RssApi.BLL.Services;

public class AuthenticationService: IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly JwtSettings _jwtSettings;
    private readonly ILogger<AuthenticationService> _logger;

    private User? _user;

    public AuthenticationService(UserManager<User> userManager, IOptions<JwtSettings> jwtOptions,
        ILogger<AuthenticationService> logger)
    {
        _userManager = userManager;
        _jwtSettings = jwtOptions.Value;
        _logger = logger;
    }
    
    public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userDto)
    {
        User user = new User()
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            DateOfBirth = userDto.DateOfBirth,
            Email = userDto.Email,
            UserName = userDto.Username
        };

        var res = await _userManager.CreateAsync(user, userDto.Password);

        return res;
    }

    public async Task<bool> ValidateUser(UserForAuthenticationDto userDto)
    {
        _user = await _userManager.FindByNameAsync(userDto.UserName);

        var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userDto.Password));
        if (!result)
        {
            _logger.LogWarning("{Action}: Authentication failed. Wrong user name or password", nameof(ValidateUser));
        }

        return result;
    }

    public async Task<string> CreateToken()
    {
        var signinCredentials = GetSigninCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signinCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private SigningCredentials GetSigninCredentials()
    {
        var key = Encoding.UTF8.GetBytes("mysupersecretkey");
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };

        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken
        (
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }
}