using RssApi.DAL.Entities;

namespace RssApi.DAL.Repository.Contracts;

public interface IFeedsRepository
{
    IQueryable<UserRssFeed> GetAll(bool trackChanges = false);

    Task<UserRssFeed?> GetByUrlAsync(string url, string userId, bool trackChanges = false);

    void CreateFeed(UserRssFeed feed);
}