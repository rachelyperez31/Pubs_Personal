using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pubs.API.Models.Modules.Roysched;
using Pubs.Domain.Entities;
using Pubs_Infrastructure.Interfaces;

namespace Pubs.API.Controllers
{
    public class RoyschedController : Controller
    {
        private readonly IRoyschedRepository _royschedRepository;

        public RoyschedController(IRoyschedRepository royschedRepository)
        {
            _royschedRepository = royschedRepository;
        }

        [HttpGet("Get Royscheds")]
        public IActionResult GetRoyscheds()
        {
            var royscheds = _royschedRepository.GetRoyscheds().Select(
                r => new RoyschedGetModel()
                {
                    TitleID = r.TitleID,
                    Lorange = r.Lorange,
                    Hirange = r.Hirange,
                    Royalty = r.Royalty
                });

            return Ok(royscheds);
        }

        [HttpGet("Get Roysched")]
        public IActionResult GetRoysched(int royschedID)
        {
            var roysched = _royschedRepository.GetRoysched(royschedID);

            return Ok(roysched);
        }

        [HttpPost("Add Roysched")]
        public IActionResult AddRoysched([FromBody] RoyschedAddModel royschedAdd)
        {
            var roysched = new Roysched()
            {
                IDCreationUser = royschedAdd.ChangeUser,
                CreationDate = royschedAdd.ChangeDate,
                TitleID = royschedAdd.TitleID,
                Lorange = royschedAdd.Lorange,
                Hirange= royschedAdd.Hirange,
                Royalty= royschedAdd.Royalty
            };

            _royschedRepository.Save(roysched);

            return Ok(roysched);
        }

        [HttpPut("Edit Roysched")]
        public IActionResult EditRoysched([FromBody] RoyschedUpdateModel royschedUpdate)
        {
            var roysched = new Roysched()
            {
                IDModifiedUser = royschedUpdate.ChangeUser,
                ModifiedDate = royschedUpdate.ChangeDate,
                TitleID = royschedUpdate.TitleID,
                Lorange = royschedUpdate.Lorange,
                Hirange = royschedUpdate.Hirange,
                Royalty = royschedUpdate.Royalty
            };

            _royschedRepository.Save(roysched);

            return Ok(roysched);
        }

        [HttpDelete("Remove Roysched")]
        public IActionResult RemoveRoysched([FromBody] RoyschedRemoveModel royschedRemove)
        {
            var roysched = new Roysched()
            {
                IDDeletedUser = royschedRemove.ChangeUser,
                DeletedDate = royschedRemove.ChangeDate,
                Deleted = true,
                RoyschedID = royschedRemove.RoyschedID
            };

            _royschedRepository.Remove(roysched);

            return Ok(roysched);
        }
    }
}
