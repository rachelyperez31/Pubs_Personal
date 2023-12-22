using Pubs.Domain.Core;

namespace Pubs.Domain.Entities
{
    public class Roysched : BaseEntity
    {
        public int RoyschedID { get; set; }
        public int TitleID { get; set; }
        public int? Lorange { get; set; }
        public int? Hirange { get; set; }
        public int Royalty { get; set; }
    }
}
