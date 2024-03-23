using EmployeeAppDemo.Models;
using Microsoft.EntityFrameworkCore;
using EmployeeAppDemo.Data;

namespace EmployeeAppDemo.Services
{
    public class EmployeeService
    {
        private readonly AppDbContext _dbContext;

        public EmployeeService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var employees = await _dbContext.Employees
            .AsNoTracking()
            .Where(emp => emp.DisplayName != null && emp.EmployeeNumber != null)
            .ToListAsync();

            return employees;
        }
    }
}
