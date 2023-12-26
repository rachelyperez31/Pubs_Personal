using Pubs.Domain.Entities;
using Pubs.Domain.Repository;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;

namespace Pubs_Infrastructure.Interfaces
{
    public interface IPub_InfoRepository : IBaseRepository<Pub_Info>
    {
        List<PublicationModel> GetPub_Infos();
        PublicationModel GetPub_Info(int pubID);
    }
}
