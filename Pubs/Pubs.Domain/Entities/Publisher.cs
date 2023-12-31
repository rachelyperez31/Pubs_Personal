using Pubs.Domain.Core;

namespace Pubs.Domain.Entities
{
    public class Publisher : Location
    {
        public int PubID { get; set; }
        public string PubName { get; set; }
        public string? Country { get; set; }
    }
}
