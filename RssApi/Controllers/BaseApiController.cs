using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RssApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BaseApiController : ControllerBase
{
    
}

