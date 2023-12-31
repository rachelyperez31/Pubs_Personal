using Pubs.Domain.Core.Interfaces;

namespace Pubs.Domain.Core
{
    public abstract class ILocationZip : BaseEntity, ILocation
    {
        public char? Zip { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
