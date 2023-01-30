using Microsoft.AspNetCore.Identity;
using RssApi.BLL.Contracts;
using RssApi.BLL.DTOs;
using RssApi.DAL.Entities;

namespace RssApi.BLL.Services;

public class AuthenticationService: IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthenticationService> _logger;

    public AuthenticationService(UserManager<User> userManager, IConfiguration configuration,
        ILogger<AuthenticationService> logger)
    {
        _userManager = userManager;
        _configuration = configuration;
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
}