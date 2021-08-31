using System.Collections.Generic;

namespace Forum.DataAccess.Entities
{
    public class Category : EntityBase
    {
        public string Title { get; set; }

        public string Description { get; set; }


        public List<Topic> Topics { get; set; }
    }
}