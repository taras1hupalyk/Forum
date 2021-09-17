using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Forum.DataAccess.Entities

{
    public class User: IdentityUser<Guid>
    {

        public string Role { get; set; }


        public UserInfo UserInfo { get; set; }
        public List<Topic> Topics { get; set; }
        public List<TopicMessage> TopicMessages { get; set; }

    }
}