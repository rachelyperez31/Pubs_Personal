using Pubs.Domain.Entities;
using Pubs.Domain.Repository;
using Pubs_Infrastructure.Interfaces.Base_Interfaces;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;

namespace Pubs_Infrastructure.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>, IPersonRepository<PublicationModel>, ILocationRepository<PublicationModel>
    {
        List<PublicationModel> GetAuthors();
        PublicationModel GetAuthor(int authorID);
        List<PublicationModel> GetAuthorsWithContract();
    }
}
