using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pubs.API.Models.Modules.Sale;
using Pubs.Domain.Entities;
using Pubs_Infrastructure.Interfaces;

namespace Pubs.API.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleRepository _saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpGet("Get Sales")]
        public IActionResult GetSales()
        {
            var sales = _saleRepository.GetSales().Select(
                s => new Sale()
                {
                    StoreID = s.StoreID,
                    OrdNum = s.OrdNum,
                    OrdDate = s.OrdDate,
                    Qty = s.Qty
                }
                );

           return Ok(sales);
        }

        [HttpGet("Get Sale")]
        public IActionResult GetSale(int storeID, string ordNum, int titleID)
        {
            var sale = _saleRepository.GetSaleByID(storeID, ordNum, titleID);

            return Ok(sale);
        }

        [HttpPost("Add Sale")]
        public IActionResult AddSale([FromBody] SaleAddModel saleAdd)
        {
            var sale = new Sale()
            {
                IDCreationUser = saleAdd.ChangeUser,
                CreationDate = saleAdd.ChangeDate,
                StoreID = saleAdd.StoreID,
                OrdNum = saleAdd.OrdNum,
                OrdDate = saleAdd.OrdDate,
                Qty = saleAdd.Qty
            };

            _saleRepository.Save(sale);

            return Ok(sale);
        }

        [HttpPut("Edit Sale")]
        public IActionResult EditSale([FromBody] SaleUpdateModel saleUpdate)
        {
            var sale = new Sale()
            {
                IDModifiedUser = saleUpdate.ChangeUser,
                ModifiedDate = saleUpdate.ChangeDate,
                StoreID = saleUpdate.StoreID,
                OrdNum= saleUpdate.OrdNum,
                TitleID = saleUpdate.TitleID,
                OrdDate= saleUpdate.OrdDate,
                Qty = saleUpdate.Qty
            };

            _saleRepository.Update(sale);

            return Ok(sale);
        }

        [HttpDelete("Remove Sale")]
        public IActionResult RemoveSale([FromBody] SaleRemoveModel saleRemove)
        {
            var sale = new Sale()
            {
                IDDeletedUser = saleRemove.ChangeUser,
                DeletedDate = saleRemove.ChangeDate,
                Deleted = true,
                StoreID = saleRemove.StoreID,
                OrdNum = saleRemove.OrdNum,
                TitleID = saleRemove.TitleID
            };

            _saleRepository.Remove(sale);

            return Ok(sale);
        }
    }
}
