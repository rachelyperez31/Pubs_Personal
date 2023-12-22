using Pubs.Domain.Core;

namespace Pubs.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public int DiscountID { get; set; }
        public int DiscountType { get; set; }
        public int? StoreID { get; set; }
        public short? LowQty { get; set; }
        public short? HighQty { get; set;}
        public decimal DiscountAmount { get; set; }
    }
}
