using System.ServiceModel.Syndication;
using System.Xml;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RssApi.BLL.Contracts;
using RssApi.BLL.DTOs;
using RssApi.DAL.Entities;
using RssApi.DAL.Repository.Contracts;

namespace RssApi.BLL.Services;

public class FeedsService: IFeedsService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ICurrentUserProvider _currentUser;
    private readonly UserManager<User> _userManager;
    private readonly ILogger<FeedsService> _logger;

    public FeedsService(IRepositoryManager repositoryManager, ICurrentUserProvider currentUser,
        UserManager<User> userManager, ILogger<FeedsService> logger)
    {
        _repositoryManager = repositoryManager;
        _currentUser = currentUser;
        _userManager = userManager;
        _logger = logger;
    }

    public async Task<bool> CreateFeed(FeedCreateDto feedDto)
    {
        var user = await GetUserFromDb();
        
        var feedPosts = GetFeedPosts(feedDto.feedUrl, user.Id).ToList();

        var feed = new UserRssFeed()
        {
            UserId = user.Id,
            FeedUri = new Uri(feedDto.feedUrl),
            FeedNews = feedPosts
        };

        _repositoryManager.Feeds.CreateFeed(feed);

        return await _repositoryManager.SaveAsync();
    }

    public async Task<IEnumerable<FeedGetDto>> GetAllActiveFeeds()
    {
        var user = await GetUserFromDb();

        var feeds = await _repositoryManager.Feeds.GetAll().Where(feed => feed.UserId.Equals(user.Id)).ToListAsync();

        return feeds.Select(f => new FeedGetDto(f?.ToString() ?? ""));
    }

    private async Task<User> GetUserFromDb()
    {
        var user = await _userManager.FindByNameAsync(_currentUser.UserName);
        if (user == null)
        {
            _logger.LogWarning("User not found: {UserName}", _currentUser.UserName);
            throw new Exception($"Unable to find user with username: {_currentUser.UserName}");
        }

        return user;
    }

    private IEnumerable<SimplePost> GetFeedPosts(string feedUrl, string userId)
    {
        using var reader = XmlReader.Create(feedUrl);
        var feed = SyndicationFeed.Load(reader);
        
        return feed
            .Items
            .Select(post => new SimplePost()
            {
                PostUri = new Uri(post.Id),
                Summary = post.Summary.Text,
                Title = post.Title?.Text,
                PostedAt = post.PublishDate.Date,
                IsRead = false,
                FeedUri = new Uri(feedUrl),
                UserId = userId
            });
    }
}