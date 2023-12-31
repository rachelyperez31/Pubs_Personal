using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pubs.API.Models.Modules.Title;
using Pubs.Domain.Entities;
using Pubs_Infrastructure.Interfaces;

namespace Pubs.API.Controllers
{
    public class TitleController : Controller
    {
        private readonly ITitleRepository _titleRepository;

        public TitleController(ITitleRepository titleRepository)
        {
            _titleRepository = titleRepository;
        }

        [HttpGet("Get Titles")]
        public IActionResult GetTitles()
        {
            var titles = _titleRepository.GetTitles().Select(
                t => new Title()
                {
                    TitleName = t.TitleName,
                    Type = t.Type,
                    PubID = t.PubID
                }
                );

            return Ok(titles);
        }

        [HttpGet("Get Title")]
        public IActionResult GetTitle(int titleID)
        {
            var title = _titleRepository.GetTitle(titleID);

            return Ok(title);   
        }

        [HttpPost("Add Title")]
        public IActionResult AddTitle([FromBody] TitleAddModel titleAdd)
        {
            var title = new Title()
            {
                IDCreationUser = titleAdd.ChangeUser,
                CreationDate = titleAdd.ChangeDate,
                TitleName = titleAdd.TitleName,
                Type = titleAdd.Type,
                PubID = titleAdd.PubID
            };

            _titleRepository.Save(title);

            return Ok(title);
        }

        [HttpPut("Edit Title")]
        public IActionResult EditTitle([FromBody] TitleUpdateModel titleUpdate)
        {
            var title = new Title()
            {
                IDModifiedUser = titleUpdate.ChangeUser,
                ModifiedDate = titleUpdate.ChangeDate,
                TitleName = titleUpdate.TitleName,
                Type = titleUpdate.Type,
                PubID = titleUpdate.PubID
            };

            _titleRepository.Update(title);

            return Ok(title);
        }

        [HttpDelete("Remove Title")]
        public IActionResult RemoveTitle([FromBody] TitleRemoveModel titleRemove) 
        {
            var title = new Title()
            {
                IDDeletedUser = titleRemove.ChangeUser,
                DeletedDate = titleRemove.ChangeDate,
                Deleted = true,
                TitleID = titleRemove.TitleID
            };

            _titleRepository.Remove(title);

            return Ok(title);
        }
    }
}
