using Microsoft.AspNetCore.Identity;

namespace RssApi.DAL.Entities;

public class User: IdentityUser<string>
{
    public string LastName { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public ICollection<UserRssFeed> UserFeeds { get; set; } = new List<UserRssFeed>();
}