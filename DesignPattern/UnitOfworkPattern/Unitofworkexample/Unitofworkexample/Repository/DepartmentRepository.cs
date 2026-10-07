using Unitofworkexample.Data;
using Unitofworkexample.Models;

namespace Unitofworkexample.Repository
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {

    }
    public class DeparmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DeparmentRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
