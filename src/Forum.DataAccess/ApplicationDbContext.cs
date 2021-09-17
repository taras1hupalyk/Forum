﻿using Forum.DataAccess.Entities;
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

        public DbSet<Category> Categories;
        public DbSet<Topic> Topics;
        public DbSet<TopicMessage> TopicMessages;
        public DbSet<User> Users;
        public DbSet<UserInfo> UserInfo;

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
