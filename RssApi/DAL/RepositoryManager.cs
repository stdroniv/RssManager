using RssApi.DAL.Repository;
using RssApi.DAL.Repository.Contracts;

namespace RssApi.DAL;

public class RepositoryManager: IRepositoryManager
{
    private readonly AppDbContext _dbContext;

    private IFeedsRepository? _feedsRepository;

    public RepositoryManager(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IFeedsRepository Feeds => _feedsRepository ??= new FeedsRepository(_dbContext);

    public async Task<bool> SaveAsync() => await _dbContext.SaveChangesAsync() > 0;
}