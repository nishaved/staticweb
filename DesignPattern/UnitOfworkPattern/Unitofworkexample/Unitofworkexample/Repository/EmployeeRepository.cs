using Microsoft.EntityFrameworkCore;
using Unitofworkexample.Data;
using Unitofworkexample.Models;

namespace Unitofworkexample.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByDepartmentAsync(int DepartmentId)
        {
            return await _context.Employees.Where(x => x.DepartmentId == DepartmentId).
                 Include(e => e.Department).ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int EmployeeId)
        {
            var employee = await _context.Employees.Include(x => x.Department).SingleOrDefaultAsync(
                 y => y.DepartmentId == EmployeeId
                );
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.Include(x => x.Department).ToListAsync();
        }
    }
}
