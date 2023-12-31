using Pubs.API.Models.Core;

namespace Pubs.API.Models.Modules.Sale
{
    public class SaleRemoveModel : BaseModel
    {
        public int StoreID { get; set; }
        public int OrdNum { get; set; }
        public int TitleID { get; set; }
    }
}
