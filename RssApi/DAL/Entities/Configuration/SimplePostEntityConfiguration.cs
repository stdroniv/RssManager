using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RssApi.DAL.Entities.Configuration;

public class SimplePostEntityConfiguration: IEntityTypeConfiguration<SimplePost>
{
    public void Configure(EntityTypeBuilder<SimplePost> builder)
    {
        builder.HasKey(it => it.PostUri);

        builder.Property(it => it.PostUri)
            .ValueGeneratedNever();

        builder.HasOne(it => it.UserRssFeed)
            .WithMany(it => it.FeedNews);
    }
}