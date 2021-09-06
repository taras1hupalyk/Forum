using System;

namespace Forum.DataAccess.Entities

{
    public class User: EntityBase
    {
        public string Nickname { get; set; }

        public string Role { get; set; }


        public UserInfo UserInfo { get; set; }

    }
}