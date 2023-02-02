namespace RssApi.DAL.Repository.Contracts;

public interface IRepositoryManager
{
    IFeedsRepository Feeds { get; }

    Task<bool> SaveAsync();
}