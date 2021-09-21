using Forum.DataAccess.Entities;
using Forum.DataAccess.Entities.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DataAccess
{
    public class ApplicationDbContext: IdentityDbContext<User, Role, Guid>
    {
        public ApplicationDbContext( DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicMessage> TopicMessages { get; set; }
        // public  DbSet<User> Users;
        public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new TopicMessageConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserInfoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
