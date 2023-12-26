using Pubs.Domain.Entities;
using Pubs.Domain.Repository;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;

namespace Pubs_Infrastructure.Interfaces
{
    public interface ITitleRepository : IBaseRepository<Title>
    {
        List<PublicationModel> GetTitles();
        PublicationModel GetTitle(int titleID);
        List<PublicationModel> GetTitlesByPublisher(string publisher);
    }
}
