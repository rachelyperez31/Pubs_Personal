using Pubs.Domain.Entities;
using Pubs.Domain.Repository;
using Pubs_Infrastructure.Interfaces.Base_Interfaces;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;

namespace Pubs_Infrastructure.Interfaces
{
    public interface IPublisherRepository : IBaseRepository<Publisher>, ILocationRepository<Publisher>
    {
        List<Publisher> GetPublishers();
        Publisher GetPublisher(int pubID);
        Publisher GetPublisherByName(string name);
        List<Publisher> GetPublishersByCountry(string country);
    }
}
