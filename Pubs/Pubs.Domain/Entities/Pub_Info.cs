using Pubs.Domain.Core;

namespace Pubs.Domain.Entities
{
    public class Pub_Info : BaseEntity
    {
        public int PubID { get; set; }
        public byte[]? Logo { get; set; }
        public string PrInfo { get; set; }
    }
}
