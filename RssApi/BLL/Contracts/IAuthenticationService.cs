using Microsoft.AspNetCore.Identity;
using RssApi.BLL.DTOs;

namespace RssApi.BLL.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userDto);
}