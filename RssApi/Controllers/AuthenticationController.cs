using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RssApi.BLL.Contracts;
using RssApi.BLL.DTOs;

namespace RssApi.Controllers;

[AllowAnonymous]
public class AuthenticationController: BaseApiController
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserForRegistrationDto userDto)
    {
        var result = await _authService.RegisterUser(userDto);

        if (!result.Succeeded)
        {
            return BadRequest(string.Join(";\n", result.Errors.Select(e => $"{e.Code} - {e.Description}")));
        }

        var token = await _authService.CreateToken();

        return Ok(new { Token = token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userDto)
    {
        if (!await _authService.ValidateUser(userDto))
        {
            return Unauthorized();
        }

        var token = await _authService.CreateToken();

        return Ok(new { Token = token });
    }
}