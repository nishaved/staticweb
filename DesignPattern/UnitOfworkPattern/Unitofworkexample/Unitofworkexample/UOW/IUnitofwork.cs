using Unitofworkexample.Repository;

namespace Unitofworkexample.UOW
{
    public interface IUnitofwork 
    {
        public DeparmentRepository Departments { get; }
        public EmployeeRepository Employees { get; }

        void CreateTransaction();
        void Commit();
        void Rollback();
        Task Save();
    }
}
