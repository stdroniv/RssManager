using RssApi.BLL.DTOs;

namespace RssApi.BLL.Contracts;

public interface IFeedsService
{
    Task<bool> CreateFeed(FeedCreateDto feedDto);

    Task<IEnumerable<FeedGetDto>> GetAllActiveFeeds();
}