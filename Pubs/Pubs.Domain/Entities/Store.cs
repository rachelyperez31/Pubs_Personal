using Pubs.Domain.Core;
using Pubs.Domain.Core.Interfaces;

namespace Pubs.Domain.Entities
{
    public class Store : Core.ILocationZip
    {
        public int StoreID { get; set; }
        public string? StoreName { get; set; }
        public string? StoreAddress { get; set; }
    }
}
