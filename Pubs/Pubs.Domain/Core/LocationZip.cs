using Pubs.Domain.Core.Interfaces;

namespace Pubs.Domain.Core
{
    public abstract class LocationZip : BaseEntity, ILocationZip
    {
        string? ILocation.City { get; set; }
        char? ILocation.State { get; set; }
        char? ILocationZip.Zip { get; set; }
    }
}
