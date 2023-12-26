using Pubs.Domain.Entities;
using Pubs_Infrastructure.Context;
using Pubs_Infrastructure.Core;
using Pubs_Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Pubs_Infrastructure.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        private readonly PubsContext _context;

        public StoreRepository(PubsContext context) : base(context) 
        {
            _context = context;
        }

        public override void Save(Store store)
        {
            _context.Stores.Add(store);
            _context.SaveChanges();
        }

        public override List<Store> GetEntities()
        {
            return _context.Stores.Where(st => !st.Deleted).ToList();   
        }

        public override void Update(Store store)
        {
            _context.Stores.Update(store);
            _context.SaveChanges();
        }

        public override void Remove(Store store)
        {
            _context.Stores.Remove(store);
            _context.SaveChanges();
        }

        public List<Store> GetStores()
        {
            return _context.Stores.Where(st => !st.Deleted).Select(
                st => new Store()
                {
                    StoreName = st.StoreName,
                    City = st.City,
                    State = st.State,
                    StoreAddress = st.StoreAddress,
                    Zip = st.Zip
                }).ToList();
        }

        public Store GetStore(int storeID)
        {
            return GetStores().Find(st => st.StoreID == storeID);
        }

        public List<Store> GetEntityByCity(string city)
        {
            return GetStores().Where(st => st.City == city).ToList();
        }

        public List<Store> GetEntityByState(char state)
        {
            return GetStores().Where(st => st.State == state).ToList();
        }
    }
}
