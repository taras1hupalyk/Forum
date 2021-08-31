using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DataAccess.Entities.Configurations


{
    public class TopicMessageConfiguration : IEntityTypeConfiguration<TopicMessage>
    {
        public void Configure(EntityTypeBuilder<TopicMessage> builder)
        {
            builder.Property(x => x.Text)
                .HasMaxLength(1024);
        }
    }
}