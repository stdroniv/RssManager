using Microsoft.AspNetCore.Mvc;
using RssApi.BLL.Contracts;
using RssApi.BLL.DTOs;

namespace RssApi.Controllers;

public class FeedController : BaseApiController
{
    private readonly IFeedsService _feedsService;

    public FeedController(IFeedsService feedsService)
    {
        _feedsService = feedsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllActive()
    {
        var result = await _feedsService.GetAllActiveFeeds();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFeed([FromBody] FeedCreateDto feedDto)
    {
        var res = await _feedsService.CreateFeed(feedDto);

        return res ? StatusCode(201) : BadRequest(new { Message = $"Failed to create Feed for Url: {feedDto.feedUrl}"});
    }
}