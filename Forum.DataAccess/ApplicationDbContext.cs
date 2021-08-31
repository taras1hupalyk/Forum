using Forum.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<Category> Categories;
        public DbSet<Topic> Topics;
        public DbSet<TopicMessage> TopicMessages;
        public DbSet<User> Users;
        public DbSet<UserInfo> UserInfo;


    }
}
