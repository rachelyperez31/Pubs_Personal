namespace Pubs.API.Models.Core
{
    public abstract class SaleBaseModel : BaseModel
    {
        public int StoreID { get; set; }
        public int OrdNum { get; set; }
        public int TitleID { get; set; }
        public DateTime OrdDate { get; set; }
        public short Qty { get; set; }
        public string Payterms { get; set; }
    }
}
