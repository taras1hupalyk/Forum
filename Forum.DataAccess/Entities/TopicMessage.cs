using System;

namespace Forum.DataAccess.Entities

{
    public class TopicMessage
    {
        public string Text { get; set; }


        public Guid TopicId{ get; set; }
        public Guid UserId { get; set; }
        public Topic Topic { get; set; }
        public User User { get; set; }
    }
}