using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RssApi.DAL.Entities.Configuration;

public class UserEntityConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(it => it.Id);

        builder
            .HasMany<UserRssFeed>(it => it.UserFeeds)
            .WithOne(f => f.User)
            .OnDelete(DeleteBehavior.Cascade);
    }
}