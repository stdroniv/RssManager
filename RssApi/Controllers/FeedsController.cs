using Microsoft.AspNetCore.Mvc;

namespace RssApi.Controllers;

public class FeedController : BaseApiController
{
    [HttpGet]
    public IActionResult GetUserInfo()
    {
        return Ok();
    }
}