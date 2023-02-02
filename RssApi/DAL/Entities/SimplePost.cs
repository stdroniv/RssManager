namespace RssApi.DAL.Entities;

public class SimplePost
{
    public Uri PostUri { get; set; } = default;

    public string Title { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public DateTime PostedAt { get; set; }

    public bool IsRead { get; set; } = false;
    
    public UserRssFeed UserRssFeed { get; set; }

    public string UserId { get; set; }
    
    public Uri FeedUri { get; set; }
}