using Pubs.Domain.Entities;
using Pubs_Infrastructure.Context;
using Pubs_Infrastructure.Core;
using Pubs_Infrastructure.Interfaces;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pubs_Infrastructure.Repositories
{
    public class DiscountRepository : BaseRepository<Discount>, IDiscountRepository
    {
        private readonly PubsContext _context;
        public DiscountRepository(PubsContext context) : base(context) 
        {
            this._context = context;
        }
        
        public override void Save(Discount discount)
        {
            _context.Discounts.Add(discount);
            _context.SaveChanges();
        }
        
        public override void Update(Discount discount)
        {
            _context.Discounts.Update(discount);
            _context.SaveChanges();
        }

        public override void Remove(Discount discount)
        {
            _context.Discounts.Remove(discount);
            _context.SaveChanges();
        }
        public override List<Discount> GetEntities()
        {
            return _context.Discounts.Where(d => !d.Deleted).ToList();
        }

        public List<PurchaseModel> GetDiscounts()
        {
            var discounts = (from d in _context.Discounts
                             join s in _context.Stores on d.StoreID equals s.StoreID
                             select new PurchaseModel
                             {
                                 StoreName = s.StoreName,
                                 DiscountType = d.DiscountType,
                                 DiscountAmount = d.DiscountAmount,
                                 HighQty = d.HighQty,
                                 LowQty = d.LowQty
                             }).ToList();
            return discounts;
        }

        public PurchaseModel GetDiscount(int discountID)
        {
            return GetDiscounts().Find(d => d.DiscountID == discountID);
        }
    }
}
