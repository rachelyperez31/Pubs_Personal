using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Pubs.API.Models.Modules.Pub_Info;
using Pubs.Domain.Entities;
using Pubs_Infrastructure.Interfaces;

namespace Pubs.API.Controllers
{
    public class Pub_InfoController : Controller
    {
        private readonly IPub_InfoRepository _pub_InfoRepository;

        public Pub_InfoController(IPub_InfoRepository pub_InfoRepository)
        {
            _pub_InfoRepository = pub_InfoRepository;
        }


        [HttpGet("Get Information of Publishers")]
        public IActionResult GetPub_Infos()
        {
            var pub_infos = _pub_InfoRepository.GetPub_Infos().Select(
                pubInf => new Pub_InfoGetModel()
                {
                    PrInfo = pubInf.PrInfo
                }
                );

            return Ok(pub_infos);
        }

        [HttpGet("Get Information of a Publisher")]
        public IActionResult GetPub_Info(int pubID)
        {
            var pub_info = _pub_InfoRepository.GetPub_Info(pubID);

            return Ok(pub_info);
        }

        [HttpPost("Add Information to a Publisher")]
        public IActionResult AddPub_Info([FromBody] Pub_InfoAddModel pub_InfoAdd)
        {
            var pub_info = new Pub_Info()
            {
                IDCreationUser = pub_InfoAdd.ChangeUser,
                CreationDate = pub_InfoAdd.ChangeDate,
                PrInfo = pub_InfoAdd.PrInfo,
                Logo = pub_InfoAdd.Logo
            };

            _pub_InfoRepository.Save(pub_info);

            return Ok(pub_info);
        }

        [HttpPut("Edit Information of a Publisher")]
        public IActionResult EditPub_Info([FromBody] Pub_InfoUpdateModel pub_InfoUpdate)
        {
            var pub_info = new Pub_Info()
            {
                IDModifiedUser = pub_InfoUpdate.ChangeUser,
                ModifiedDate = pub_InfoUpdate.ChangeDate,
                PrInfo = pub_InfoUpdate.PrInfo
            };

            _pub_InfoRepository.Update(pub_info);

            return Ok(pub_info);
        }

        [HttpDelete("Remove Information of a Publisher")]
        public IActionResult RemovePub_Info([FromBody] Pub_InfoRemoveModel pub_InfoRemove) 
        {
            var pub_info = new Pub_Info()
            {
                PubID = pub_InfoRemove.PubID,
                Deleted = true,
                IDDeletedUser = pub_InfoRemove.ChangeUser,
                DeletedDate = pub_InfoRemove.ChangeDate
            };

            _pub_InfoRepository.Remove(pub_info);

            return Ok(pub_info);
        }
    }
}
