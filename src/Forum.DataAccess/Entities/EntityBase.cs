﻿using System;


namespace Forum.DataAccess.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
