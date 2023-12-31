using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pubs.API.Models.Modules.Employee;
using Pubs.Domain.Entities;
using Pubs_Infrastructure.Interfaces;

namespace Pubs.API.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("Get Employees")]
        public IActionResult GetEmployees()
        {
            var employees = _employeeRepository.GetEmployees().Select(
                emp => new EmployeeGetModel()
                {
                    FName = emp.FName,
                    LName = emp.LName,
                    JobID = emp.JobID,
                    JobLvl = emp.JobLvl,
                    PubID = emp.PubID
                }).ToList();

            return Ok(employees);
        }

        [HttpGet("Get Employee")]
        public IActionResult GetEmployee(int empID)
        {
           var employee = _employeeRepository.GetEmployee(empID);

            return Ok(employee);
        }

        [HttpPost("Add Employee")]
        public IActionResult AddEmployee([FromBody] EmployeeAddModel employeeAdd)
        {
            var employee = new Employee()
            {
                IDCreationUser = employeeAdd.ChangeUser,
                CreationDate = employeeAdd.ChangeDate,
                FName = employeeAdd.FName,
                LName = employeeAdd.LName,
                JobID = employeeAdd.JobID,
                JobLvl = employeeAdd.JobLvl,
                PubID = employeeAdd.PubID
            };

            return Ok(employee);
        }

        [HttpPut("Edit Employee")]
        public IActionResult EditEmployee([FromBody] EmployeeUpdateModel employeeUpdate)
        {
            var employee = new Employee()
            {
                IDModifiedUser = employeeUpdate.ChangeUser,
                ModifiedDate = employeeUpdate.ChangeDate,
                FName = employeeUpdate.FName,
                LName = employeeUpdate.LName,
                JobID = employeeUpdate.JobID,
                JobLvl = employeeUpdate.JobLvl,
                PubID = employeeUpdate.PubID
            };

            _employeeRepository.Update(employee);

            return Ok(employee);
        }

        [HttpDelete("Remove Employee")]
        public IActionResult RemoveEmployee([FromBody] EmployeeRemoveModel employeeRemove)
        {
            var employee = new Employee()
            {
                EmpID = employeeRemove.EmpID,
                Deleted = true,
                IDDeletedUser = employeeRemove.ChangeUser,
                DeletedDate = employeeRemove.ChangeDate
            };

            _employeeRepository.Remove(employee);

            return Ok(employee);
        }
    }
}
