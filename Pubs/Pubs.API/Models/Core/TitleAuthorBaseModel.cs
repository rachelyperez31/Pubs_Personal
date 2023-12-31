namespace Pubs.API.Models.Core
{
    public abstract class TitleAuthorBaseModel : BaseModel
    {
        public int AuID { get; set; }
        public int TitleID { get; set; }
        public short? AuOrd { get; set; }
        public int? RoyaltyPer { get; set; }
    }
}
