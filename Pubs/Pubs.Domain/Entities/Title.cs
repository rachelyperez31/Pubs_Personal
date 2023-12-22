﻿using Pubs.Domain.Core;
using System;

namespace Pubs.Domain.Entities
{
    public class Title : BaseEntity
    {
        public int TitleID { get; set; }
        public string TitleName { get; set; }
        public char Type { get; set; }
        public int? PubID { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public string? Notes { get; set; }
        public DateTime? PubDate { get; set; }
    }
}
