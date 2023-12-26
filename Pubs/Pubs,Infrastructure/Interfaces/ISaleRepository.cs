using Pubs.Domain.Entities;
using Pubs.Domain.Repository;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;

namespace Pubs_Infrastructure.Interfaces
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        List<PurchaseModel> GetSales();
        PurchaseModel GetSaleByID(int storeID, string ordNum, int titleID);
    }
}
