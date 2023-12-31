namespace Pubs.API.Models.Core
{
    public abstract class RoyschedBaseModel : BaseModel
    {
        public int TitleID { get; set; }
        public int? Lorange { get; set; }
        public int? Hirange { get; set; }
        public int Royalty { get; set; }
    }
}
