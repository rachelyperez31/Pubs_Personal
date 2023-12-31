using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pubs.API.Models.Modules.Publisher;
using Pubs.Domain.Entities;
using Pubs_Infrastructure.Interfaces;

namespace Pubs.API.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet("Get Publishers")]
        public IActionResult GetPublishers()
        {
            var publishers = _publisherRepository.GetPublishers().Select(
                pub => new Publisher()
                {
                    PubName = pub.PubName,
                    Country = pub.Country,
                    City = pub.City,
                    State = pub.State
                });
            
            return Ok(publishers);
        }

        [HttpGet("Get Publisher")]
        public IActionResult GetPublisher(int pubID)
        {
            var publisher = _publisherRepository.GetPublisher(pubID);

            return Ok(publisher);   
        }

        [HttpPost("Add Publisher")]
        public IActionResult AddPublisher([FromBody] PublisherAddModel publisherAdd)
        {
            var publisher = new Publisher()
            {
                IDCreationUser = publisherAdd.ChangeUser,
                CreationDate = publisherAdd.ChangeDate,
                PubName = publisherAdd.PubName,
                Country = publisherAdd.Country,
                City = publisherAdd.City,
                State = publisherAdd.State
            };

            _publisherRepository.Save(publisher);

            return Ok(publisher);
        }

        [HttpPut("Edit Publisher")]
        public IActionResult EditPublisher([FromBody] PublisherUpdateModel publisherUpdate)
        {
            var publisher = new Publisher()
            {
                IDModifiedUser = publisherUpdate.ChangeUser,
                ModifiedDate = publisherUpdate.ChangeDate,
                PubName = publisherUpdate.PubName,
                Country = publisherUpdate.Country,
                City = publisherUpdate.City,
                State = publisherUpdate.State
            };

            _publisherRepository.Update(publisher);

            return Ok(publisher);
        }

        [HttpDelete("Remove Publisher")]
        public IActionResult RemovePublisher([FromBody] PublisherRemoveModel publisherRemove)
        {
            var publisher = new Publisher()
            {
                IDDeletedUser = publisherRemove.ChangeUser,
                DeletedDate = publisherRemove.ChangeDate,
                Deleted = true
            };

            _publisherRepository.Remove(publisher);

            return Ok(publisher);
        }
    }
}
