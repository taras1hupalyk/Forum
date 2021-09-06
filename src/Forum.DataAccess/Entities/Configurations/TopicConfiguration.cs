using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DataAccess.Entities.Configurations


{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.Property(x => x.Title)
                .HasMaxLength(200);
            builder.Property(x => x.Title)
                .HasMaxLength(1000);

            builder.HasMany(x => x.TopicMessages)
                .WithOne(x => x.Topic)
                .HasForeignKey(x => x.TopicId);

        }
    }
}