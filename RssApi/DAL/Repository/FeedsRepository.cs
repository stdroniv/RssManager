using Microsoft.EntityFrameworkCore;
using RssApi.DAL.Entities;
using RssApi.DAL.Repository.Contracts;

namespace RssApi.DAL.Repository;

public class FeedsRepository: RepositoryBase<UserRssFeed>, IFeedsRepository
{
    public FeedsRepository(AppDbContext context) 
        : base(context)
    {
    }

    public IQueryable<UserRssFeed> GetAll(bool trackChanges = false) =>
        FindAll(trackChanges)
            .Include(o => o.FeedNews);

    public async Task<UserRssFeed?> GetByUrlAsync(string url, string userId, bool trackChanges = false) =>
        await FindByCondition(o => o.FeedUri.Equals(url) && o.UserId.Equals(userId), trackChanges)
            .Include(o => o.FeedNews)
            .SingleOrDefaultAsync();

    public void CreateFeed(UserRssFeed feed) => Add(feed);
}