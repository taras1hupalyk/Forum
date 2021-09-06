using System;

namespace Forum.DataAccess.Entities
{
    public class UserInfo : EntityBase
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public string PhoneNumber { get; set; }


        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}