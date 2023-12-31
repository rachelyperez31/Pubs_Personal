﻿using Pubs.Domain.Core.Interfaces;

namespace Pubs.Domain.Core
{
    public abstract class Location : BaseEntity, ILocation
    {
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
