using Microsoft.AspNetCore.Mvc;
using Pubs.API.Models.Modules.Store;
using Pubs.Domain.Entities;
using Pubs_Infrastructure.Interfaces;

namespace Pubs.API.Controllers
{
    public class StoreController : Controller
    {
        public readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [HttpGet("Get Stores")]
        public IActionResult GetStores()
        {
            var stores = _storeRepository.GetStores().Select(
                st => new StoreGetModel()
                {
                    StoreName = st.StoreName,
                    StoreAddress = st.StoreAddress,
                    Zip = st.Zip,
                    City = st.City,
                    State = st.State
                }
                );

            return Ok( stores );
        }

        [HttpGet("Get Store")]
        public IActionResult GetStore(int storeID)
        {
            var store = _storeRepository.GetStore(storeID);

            return Ok( store );
        }

        [HttpPost("Add Store")]
        public IActionResult AddStore([FromBody] StoreAddModel storeAdd)
        {
            var store = new Store()
            {
                IDCreationUser = storeAdd.ChangeUser,
                CreationDate = storeAdd.ChangeDate,
                StoreName = storeAdd.StoreName,
                StoreAddress = storeAdd.StoreAddress,
                Zip = storeAdd.Zip,
                City = storeAdd.City,
                State = storeAdd.State
            };

            _storeRepository.Save( store );

            return Ok( store ); 
        }

        [HttpPut("Edit Store")]
        public IActionResult EditStore([FromBody] StoreUpdateModel storeUpdate)
        {
            var store = new Store()
            {
                IDModifiedUser = storeUpdate.ChangeUser,
                ModifiedDate = storeUpdate.ChangeDate,
                StoreName = storeUpdate.StoreName,
                StoreAddress = storeUpdate.StoreAddress,
                Zip = storeUpdate.Zip,
                City = storeUpdate.City,
                State = storeUpdate.State
            };

            _storeRepository.Update( store );

            return Ok( store ); 
        }

        [HttpDelete("Remove Store")]
        public IActionResult RemoveStore([FromBody] StoreRemoveModel storeRemove)
        {
            var store = new Store() 
            {
                IDDeletedUser = storeRemove.ChangeUser,
                DeletedDate = storeRemove.ChangeDate,
                Deleted = true,
                StoreID = storeRemove.StoreID
            };

            _storeRepository.Remove( store );

            return Ok( store );
        }
    }
}
