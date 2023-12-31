using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pubs.API.Models.Modules.Author;
using Pubs.Domain.Entities;
using Pubs_Infrastructure.Interfaces;

namespace Pubs.API.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet("Get Authors")]
        
        public IActionResult GetAuthors()
        {
            var authors = _authorRepository.GetAuthors().Select(
                au => new AuthorGetModel()
                {
                    AuFName = au.AuFName,
                    AuLName = au.AuLName,
                    Phone = au.Phone,
                    Address = au.Address,
                    Contract = au.Contract,
                    City = au.City,
                    State = au.State
                }
                ).ToList();

            return Ok(authors);
        }

        [HttpGet("Get Author")]
        public IActionResult GetAuthor(int auID)
        {
            var author = _authorRepository.GetAuthor(auID);
            return Ok(author);
        }

        [HttpPost("Add Author")]
        public IActionResult AddAuthor([FromBody] AuthorAddModel authorAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Author author = new Author()
            {
                IDCreationUser = authorAdd.ChangeUser,
                CreationDate = authorAdd.ChangeDate,
                AuLName = authorAdd.AuLName,
                AuFName = authorAdd.AuFName,
                Phone = authorAdd.Phone,
                Address = authorAdd.Address,
                Contract = authorAdd.Contract,
                City = authorAdd.City,
                State = authorAdd.State
            };

            _authorRepository.Save(author);

            return Ok(author);
        }

        [HttpPut("Edit Author")]
        public IActionResult EditAuthor([FromBody] AuthorUpdateModel authorUpdate)
        {
            Author author = new Author()
            {
                IDCreationUser = authorUpdate.ChangeUser,
                CreationDate = authorUpdate.ChangeDate,
                AuLName = authorUpdate.AuLName,
                AuFName = authorUpdate.AuFName,
                Phone = authorUpdate.Phone,
                Address = authorUpdate.Address,
                Contract = authorUpdate.Contract,
                City = authorUpdate.City,
                State = authorUpdate.State
            };

            _authorRepository.Update(author);

            return Ok(author);
        }

        [HttpDelete("Remove Author")]
        public IActionResult RemoveAuthor([FromBody] AuthorRemoveModel authorRemove)
        {
            Author author = new Author()
            {
                AuID = authorRemove.AuID,
                Deleted = true,
                IDDeletedUser = authorRemove.ChangeUser,
                DeletedDate = authorRemove.ChangeDate
            };

            _authorRepository.Remove(author);

            return Ok();
        }
    }
}
