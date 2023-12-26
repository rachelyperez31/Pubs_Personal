using Pubs.Domain.Entities;
using Pubs.Domain.Repository;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;

namespace Pubs_Infrastructure.Interfaces
{
    public interface IRoyschedRepository : IBaseRepository<Roysched>
    {
        List<PublicationModel> GetRoyscheds();
        PublicationModel GetRoysched(int royschedID);
    }
}
