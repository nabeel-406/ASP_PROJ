using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PractiseDemo.data;
using PractiseDemo.Models;

namespace PractiseDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _dbContext;
        public EmployeeController(EmployeeDbContext employeeDb)
        {
            _dbContext = employeeDb;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employee = await _dbContext.EmpTable.ToListAsync();
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            employee.Id = Guid.NewGuid();
            await _dbContext.EmpTable.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return Ok(employee);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee =
            await _dbContext.EmpTable.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateEmployee)
        {
            var employee = await _dbContext.EmpTable.FindAsync(id);
            if (employee==null)
            {
                return NotFound();
            }
            employee.Name = updateEmployee.Name;
            employee.Departmnet = updateEmployee.Departmnet;
            employee.Number = updateEmployee.Number;
            employee.Salary = updateEmployee.Salary;

            await _dbContext.SaveChangesAsync();
            
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> deleteEmployee([FromRoute] Guid id)
        {
            var employee = await _dbContext.EmpTable.FindAsync(id);
            if (employee==null)
            {
                return NotFound();
            }
            _dbContext.EmpTable.Remove(employee);
            await _dbContext.SaveChangesAsync();

            return Ok(employee);
        }
    }
}