namespace Pubs.API.Models.Core
{
    public abstract class DiscountBaseModel : BaseModel
    {
        public string DiscountType { get; set; }
        public int? StoreID { get; set; }
        public short? LowQty { get; set; }
        public short? HighQty { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
