using Pubs.Domain.Entities;
using Pubs_Infrastructure.Context;
using Pubs_Infrastructure.Core;
using Pubs_Infrastructure.Interfaces;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pubs_Infrastructure.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        private readonly PubsContext _context;

        public SaleRepository(PubsContext context) : base(context)
        {
            _context = context;
        }

        public override void Save(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public override List<Sale> GetEntities()
        {
            return _context.Sales.Where(s => !s.Deleted).ToList();    
        }

        public override void Update(Sale sale) 
        { 
            _context.Sales.Update(sale);
            _context.SaveChanges();
        }

        public override void Remove(Sale sale)
        {
            _context.Sales.Remove(sale);
            _context.SaveChanges();
        }

        public List<PurchaseModel> GetSales()
        {
            var sales = (from sa in _context.Sales
                         join st in _context.Stores on sa.StoreID equals st.StoreID
                         join t in _context.Titles on sa.TitleID equals t.TitleID
                         select new PurchaseModel()
                         {
                             OrdNum = sa.OrdNum,
                             TitleName = t.TitleName,
                             StoreName = st.StoreName,
                             Qty = sa.Qty,
                             Price = t.Price,
                             OrdDate = sa.OrdDate
                         }).ToList();
            return sales;
        }

        public PurchaseModel GetSaleByID(int storeID, string ordNum, int titleID)
        {
            var id = new { StoreID = storeID, OrdNum = ordNum, TitleID = titleID };
            return GetSales().Find(sa => sa.Equals(id));
        }
    }
}
