using System;

namespace Pubs_Infrastructure.Models
{
    public class PurchaseModel
    {
        public int StoreID { get; set; }
        public string? StoreName { get; set; }
        public int DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public short? LowQty { get; set; }
        public short? HighQty { get; set; }
        public int OrdNum { get; set; }
        public int TitleID { get; set; }
        public short Qty { get; set; }
        public string TitleName { get; set; }
        public char Type { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int DiscountID { get; set; }
        public DateTime OrdDate { get; set; }
    }
}
