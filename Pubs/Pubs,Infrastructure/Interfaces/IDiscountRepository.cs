using Pubs.Domain.Entities;
using Pubs.Domain.Repository;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;

namespace Pubs_Infrastructure.Interfaces
{
    public interface IDiscountRepository : IBaseRepository<Discount>
    { 
        List<PurchaseModel> GetDiscounts();
        PurchaseModel GetDiscount(int discountID);
    } 
}
