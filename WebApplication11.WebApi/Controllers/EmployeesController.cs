using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication11.WebApi.Data;
using WebApplication11.WebApi.Models;
using WebApplication11.WebApi.Models.Entities;

namespace WebApplication11.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();
            // Placeholder implementation
            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public  IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            // Placeholder implementation
            if (employee is null)
            {
                return NotFound("employe not fount");
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee(AddEmployeeDto addEmployeeDto)

        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary

            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();
            return Ok(employeeEntity);
        }
    

    [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var existingEmployee = await dbContext.Employees.FindAsync(id);
            if (existingEmployee is null)
            {
                return NotFound("employee not found");
            }
            existingEmployee.Name = updateEmployeeDto.Name;
            existingEmployee.Email = updateEmployeeDto.Email;
            existingEmployee.Phone = updateEmployeeDto.Phone;
            existingEmployee.Salary = updateEmployeeDto.Salary;
            dbContext.SaveChanges();
            return Ok(existingEmployee);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var existingEmployee = dbContext.Employees.Find(id);
            if (existingEmployee is null)
            {
                return NotFound("employee not found");
            }
            dbContext.Employees.Remove(existingEmployee);
            dbContext.SaveChanges();
            return Ok("remove employee successfully");
        }
    }

    }
