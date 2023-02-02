namespace RssApi.BLL.Contracts;

public interface ICurrentUserProvider
{
    public string UserName { get; }
}