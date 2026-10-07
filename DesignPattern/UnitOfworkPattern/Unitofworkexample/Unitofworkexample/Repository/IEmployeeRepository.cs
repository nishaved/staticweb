using Unitofworkexample.Models;

namespace Unitofworkexample.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
     {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int EmployeeId);
        Task<IEnumerable<Employee>> GetEmployeeByDepartmentAsync(int DepartmentId);
    }
}
