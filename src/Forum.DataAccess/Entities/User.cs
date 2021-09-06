using System;
using System.Collections.Generic;

namespace Forum.DataAccess.Entities

{
    public class User: EntityBase
    {
        public string Nickname { get; set; }

        public string Role { get; set; }


        public UserInfo UserInfo { get; set; }
        public List<Topic> Topics { get; set; }
        public List<TopicMessage> TopicMessages { get; set; }

    }
}