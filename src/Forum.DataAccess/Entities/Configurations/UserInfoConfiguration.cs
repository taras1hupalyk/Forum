using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.DataAccess.Entities.Configurations

{
    public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.Property(x => x.LastName)
                .HasMaxLength(64);
            builder.Property(x => x.FirstName)
                .HasMaxLength(64);
            builder.Property(x => x.Patronymic)
                .HasMaxLength(64);
            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(12);
        }
    }
}