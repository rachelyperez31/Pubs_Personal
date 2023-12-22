﻿using System;

namespace Pubs.Domain.Core
{
    public abstract class BaseEntity
    {
        public int IDCreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public int? IDModifiedUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? IDDeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
