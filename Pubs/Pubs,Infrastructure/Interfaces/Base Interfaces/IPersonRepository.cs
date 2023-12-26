using Pubs.Domain.Core;
using System.Collections.Generic;

namespace Pubs_Infrastructure.Interfaces
{
    public interface IPersonRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetPeopleByFirstName(string firstName);
        List<TEntity> GetPeopleByLastName(string lastName);
        List<TEntity> GetPeopleByFullName(string firstName, string lastName);
    }
}
