using Pubs.Domain.Core;

namespace Pubs.Domain.Entities
{
    public class TitleAuthor : BaseEntity
    {
        public int AuID { get; set; }
        public int TitleID { get; set; }
        public short? AuOrd { get; set; }
        public int? RoyaltyPer { get; set; }
    }
}
