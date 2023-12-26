namespace Pubs.Domain.Core.Interfaces
{
    public interface ILocationZip : ILocation
    {
        public char? Zip { get; set; }
    }
}
