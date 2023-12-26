using Pubs.Domain.Entities;
using Pubs.Domain.Repository;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;

namespace Pubs_Infrastructure.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>, IPersonRepository<EmploymentModel>
    {
        EmploymentModel GetEmployee(int empID);
        List<EmploymentModel> GetEmployees();
        List<EmploymentModel> GetEmployeesByJobLvl(short jobLvl);
    }
}
