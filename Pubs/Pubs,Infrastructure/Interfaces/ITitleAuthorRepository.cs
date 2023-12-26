using Pubs.Domain.Entities;
using Pubs.Domain.Repository;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;

namespace Pubs_Infrastructure.Interfaces
{
    public interface ITitleAuthorRepository : IBaseRepository<TitleAuthor>
    {
       List<PublicationModel> GetTitleAuthors();
       PublicationModel GetTitleAuthor(int titleID, int authorID);
       PublicationModel GetTitleAuthorByAuthor(string firstname, string lastname);
       PublicationModel GetTitleAuthorByTitle(string title);
    }
}
