namespace Pubs.API.Models.Core
{
    public abstract class StoreBaseModel : BaseModel
    {
        public string? StoreName { get; set; }
        public string? StoreAddress { get; set; }
        public char? Zip { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
