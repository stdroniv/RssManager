using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RssApi.DAL.Entities;

namespace RssApi.Controllers;

public class UsersController : BaseApiController
{
    private readonly UserManager<User> _userManager;

    public UsersController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("users")]
    public async Task<ActionResult<int>> GetAllUsersCount()
    {
        var count = await _userManager.Users.CountAsync();

        return count;
    }
}