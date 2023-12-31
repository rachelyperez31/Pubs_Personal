using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pubs.API.Models.Modules.Discount;
using Pubs.Domain.Entities;
using Pubs_Infrastructure.Interfaces;

namespace Pubs.API.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpGet("Get Discounts")]
        public IActionResult GetDiscounts()
        {
            var discounts = _discountRepository.GetDiscounts().Select(
                d => new DiscountGetModel()
                {
                    DiscountType = d.DiscountType,
                    LowQty = d.LowQty,
                    HighQty = d.HighQty,
                    DiscountAmount = d.DiscountAmount
                }).ToList();

            return Ok(discounts);
        }

        [HttpGet("Get Discount")]
        public IActionResult GetDiscount(int discountID)
        {
            var discount = _discountRepository.GetDiscount(discountID);

            return Ok(discount);
        }

        [HttpPost("Add Discount")]
        public IActionResult AddDiscount([FromBody] DiscountAddModel discountAdd)
        {
            var discount = new Discount()
            {
                IDCreationUser = discountAdd.ChangeUser,
                CreationDate = discountAdd.ChangeDate,
                DiscountType = discountAdd.DiscountType,
                LowQty = discountAdd.LowQty,
                HighQty = discountAdd.HighQty,
                DiscountAmount = discountAdd.DiscountAmount
            };
                
            _discountRepository.Save(discount);
            return Ok();
        }

        [HttpPut("Edit Discount")]
        public IActionResult EditDiscount([FromBody] DiscountUpdateModel discountUpdate)
        {
            var discount = new Discount()
            {
                IDModifiedUser = discountUpdate.ChangeUser,
                ModifiedDate = discountUpdate.ChangeDate,
                DiscountType = discountUpdate.DiscountType,
                LowQty = discountUpdate.LowQty,
                HighQty = discountUpdate.HighQty,
                DiscountAmount = discountUpdate.DiscountAmount
            };
            return Ok();
        }

        // GET: DiscountController/Delete/5
        public IActionResult RemoveDiscount([FromBody] DiscountRemoveModel discountRemove)
        {
            var discount = new Discount()
            {
                DiscountID = discountRemove.DiscountID,
                Deleted = true,
                IDDeletedUser = discountRemove.ChangeUser,
                DeletedDate = discountRemove.ChangeDate
            };

            _discountRepository.Remove(discount);

            return Ok();
        }
    }
}
