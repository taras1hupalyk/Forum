using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DataAccess.Entities.Configurations


{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            
            builder.Property(x => x.Role)
                .HasMaxLength(10);

            builder.HasOne(x => x.UserInfo)
                .WithOne(x => x.User)                
                .IsRequired(false);
            builder.HasMany(x => x.Topics)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.TopicMessages)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}