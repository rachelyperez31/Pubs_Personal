namespace Pubs.API.Models.Core
{
    public abstract class Pub_InfoBaseModel : BaseModel
    {
        public byte[]? Logo { get; set; }
        public string PrInfo { get; set; }
    }
}
