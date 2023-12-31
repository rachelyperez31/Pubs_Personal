using Pubs.Domain.Core;
using Pubs.Domain.Entities;
using System.Collections.Generic;

namespace Pubs_Infrastructure.Interfaces.Base_Interfaces
{
    public interface ILocationRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetEntityByCity(string city);
        List<TEntity> GetEntityByState(string state);
    }
}
