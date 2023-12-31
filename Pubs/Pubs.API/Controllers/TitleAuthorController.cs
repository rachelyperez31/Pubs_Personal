using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pubs.API.Models.Modules.TitleAuthor;
using Pubs.Domain.Entities;
using Pubs_Infrastructure.Interfaces;

namespace Pubs.API.Controllers
{
    public class TitleAuthorController : Controller
    {
        private readonly ITitleAuthorRepository _titleAuthorRepository;

        public TitleAuthorController(ITitleAuthorRepository titleAuthorRepository)
        {
            _titleAuthorRepository = titleAuthorRepository;
        }

        [HttpGet("Get Title-Authors")]
        public IActionResult GetTitleAuthors()
        {
            var titleAuthors = _titleAuthorRepository.GetTitleAuthors().Select(
                ta => new TitleAuthorGetModel()
                {
                    TitleID = ta.TitleID,
                    AuID = ta.AuID
                });

            return Ok(titleAuthors);
        }

        [HttpGet("Get Title-Author")]
        public IActionResult GetTitleAuthor(int titleID, int authorID)
        {
            var titleAuthor = _titleAuthorRepository.GetTitleAuthor(titleID, authorID);

            return Ok(titleAuthor);
        }

        [HttpPost("Add Title-Author")]
        public IActionResult AddTitleAuthor([FromBody] TitleAuthorAddModel titleAuthorAdd)
        {
            var titleAuthor = new TitleAuthor()
            {
                IDCreationUser = titleAuthorAdd.ChangeUser,
                CreationDate = titleAuthorAdd.ChangeDate,
                TitleID = titleAuthorAdd.TitleID,
                AuID = titleAuthorAdd.AuID
            };

            _titleAuthorRepository.Save(titleAuthor);

            return Ok(titleAuthor);
        }

        [HttpPut("Edit Title-Author")]
        public IActionResult EditTitleAuthor([FromBody] TitleAuthorUpdateModel titleAuthorUpdate)
        {
            var titleAuthor = new TitleAuthor()
            {
                IDModifiedUser = titleAuthorUpdate.ChangeUser,
                ModifiedDate = titleAuthorUpdate.ChangeDate,
                TitleID = titleAuthorUpdate.TitleID,
                AuID = titleAuthorUpdate.AuID
            };

            _titleAuthorRepository.Update(titleAuthor);   

            return Ok(titleAuthor);
        }

        [HttpDelete("Remove Title-Author")]
        public IActionResult RemoveTitleAuthor([FromBody] TitleAuthorRemoveModel titleAuthorRemove)
        {
            var titleAuthor = new TitleAuthor()
            {
                IDDeletedUser = titleAuthorRemove.ChangeUser,
                DeletedDate = titleAuthorRemove.ChangeDate,
                Deleted = true,
                TitleID = titleAuthorRemove.TitleID,
                AuID= titleAuthorRemove.AuID
            };

            _titleAuthorRepository.Remove(titleAuthor);

            return Ok(titleAuthor); 
        }
    }
}
