namespace Pubs.Domain.Core.Interfaces
{
    public interface ILocationZip : ILocation
    {
        char? Zip { get; set; }
    }
}
