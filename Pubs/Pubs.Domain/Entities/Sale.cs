using Pubs.Domain.Core;
using System;

namespace Pubs.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public int StoreID { get; set; }
        public int OrdNum { get; set; }
        public int TitleID { get; set; }
        public DateTime OrdDate { get; set; }
        public short Qty { get; set; }
        public string Payterms { get; set; }
    }
}
