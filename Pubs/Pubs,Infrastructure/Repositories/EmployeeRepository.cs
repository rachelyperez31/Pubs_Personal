using Pubs.Domain.Entities;
using Pubs_Infrastructure.Context;
using Pubs_Infrastructure.Core;
using Pubs_Infrastructure.Interfaces;
using Pubs_Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pubs_Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly PubsContext _context;
        private readonly EmploymentModel _employmentModel;
        public EmployeeRepository(PubsContext context) : base(context)
        {
            _context = context;
        }

        public override void Save(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
        }
        
        public override void Update(Employee employee)
        {
            _context.Employee.Update(employee);
            _context.SaveChanges();
        }

        public override void Remove(Employee employee)
        {
            _context.Employee.Remove(employee);
            _context.SaveChanges();
        }
        public override List<Employee> GetEntities()
        {
            return _context.Employee.Where(emp => !emp.Deleted).ToList();
        }

        public List<EmploymentModel> GetEmployeesByJobLvl(short jobLvl)
        {
            var employees = (from emp in _context.Employee
                            where emp.JobLvl == jobLvl
                            select new EmploymentModel
                            {
                                FName = emp.FName,
                                LName = emp.LName,
                                JobLvl = emp.JobLvl
                            }).ToList();

            return employees;
        }

        public List<EmploymentModel> GetPeopleByFirstName(string firstName)
        {
            return GetEmployees().Where(emp => emp.FName == firstName).ToList();    
        }

        public List<EmploymentModel> GetPeopleByFullName(string firstName, string lastName)
        {
            return GetEmployees().Where(emp => emp.FName == firstName && emp.LName == lastName).ToList();
        }

        public List<EmploymentModel> GetPeopleByLastName(string lastName)
        {
            return GetEmployees().Where(emp => emp.LName == lastName).ToList();
        }

        public EmploymentModel GetEmployee(int empID)
        {
            return GetEmployees().Find(emp => emp.EmpID == empID);
        }

        public List<EmploymentModel> GetEmployees()
        {
            var employees = (from emp in _context.Employee
                            join pub in _context.Publishers on emp.PubID equals pub.PubID
                            join j in _context.Jobs on emp.JobID equals j.JobID
                            select new EmploymentModel()
                            {
                                FName = emp.FName,
                                LName = emp.LName,
                                PubName = pub.PubName,
                                JobDesc = j.JobDesc
                            }).ToList();

            return employees;
        }
    }
}
