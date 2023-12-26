using Pubs.Domain.Entities;
using Pubs.Domain.Repository;
using Pubs_Infrastructure.Interfaces.Base_Interfaces;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;

namespace Pubs_Infrastructure.Interfaces
{
    public interface IStoreRepository : IBaseRepository<Store>, ILocationRepository<Store>
    {
        List<Store> GetStores();
        Store GetStore(int storeID);

    }
}
