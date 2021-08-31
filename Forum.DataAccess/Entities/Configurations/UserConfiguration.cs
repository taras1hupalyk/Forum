using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DataAccess.Entities.Configurations


{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Nickname)
                 .HasMaxLength(128);
            builder.Property(x => x.Role)
                .HasMaxLength(10);

            builder.HasOne(x => x.UserInfo)
                .WithOne(x => x.User)                
                .IsRequired(false);
        }
    }
}