namespace Pubs.API.Models.Core
{
    public abstract class PublisherBaseModel : BaseModel
    {
        public string PubName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
