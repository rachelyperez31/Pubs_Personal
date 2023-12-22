namespace Pubs.Domain.Core.Interfaces
{
    public interface ILocation
    {
        string? City { get; set; }
        char? State { get; set; }
    }
}
