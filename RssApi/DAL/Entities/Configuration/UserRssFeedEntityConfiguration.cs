using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RssApi.DAL.Entities.Configuration;

public class UserRssFeedEntityConfiguration: IEntityTypeConfiguration<UserRssFeed>
{
    public void Configure(EntityTypeBuilder<UserRssFeed> builder)
    {
        builder.HasKey(it => new { it.UserId, it.FeedUri });
    }
}