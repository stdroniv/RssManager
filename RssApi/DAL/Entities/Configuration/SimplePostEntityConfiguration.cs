using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RssApi.DAL.Entities.Configuration;

public class SimplePostEntityConfiguration: IEntityTypeConfiguration<SimplePost>
{
    public void Configure(EntityTypeBuilder<SimplePost> builder)
    {
        builder.HasKey(it => it.PostUri);
        
    }
}