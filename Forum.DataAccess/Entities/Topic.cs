using System;

namespace Forum.DataAccess.Entities

{
    public class Topic : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}