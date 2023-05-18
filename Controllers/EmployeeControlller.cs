using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecordsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RecordsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControlller : ControllerBase
    {
        private readonly CompanyContext _dbContext;

        public EmployeeControlller(CompanyContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get an Employee Record
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>>GetEmployee()
        {
            if(_dbContext == null)
            {
                return NotFound();
            }

            return await _dbContext.Employees.ToListAsync();
        }

        //Get an Employee Record
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>>GetEmployee(int id)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]

        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {

            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Employee),new { id = employee.EmployeeId},employee);
        }

    }
}
