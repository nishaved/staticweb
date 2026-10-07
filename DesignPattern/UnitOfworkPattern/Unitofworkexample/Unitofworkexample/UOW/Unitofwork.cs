using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Unitofworkexample.Data;
using Unitofworkexample.Models;
using Unitofworkexample.Repository;

namespace Unitofworkexample.UOW
{
    public class Unitofwork : IUnitofwork, IDisposable
    {
        //variable hold karke context k through
        public ApplicationDbContext Context = null;
        // ye transaction k variable ko hold karega
        private IDbContextTransaction _obj = null;

        

        public DeparmentRepository Departments { get; private set; }

        public EmployeeRepository Employees { get; private set; }

        

        public Unitofwork(ApplicationDbContext _context)
        {
            Context = _context;
            Employees = new EmployeeRepository(Context);
            Departments = new DeparmentRepository(Context);
        }
        public void Commit()
        {
           _obj.Commit(); 
        }

        public void CreateTransaction()
        {
             _obj = Context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _obj.Rollback();
            _obj.Dispose();
        }

        public async Task Save()
        {
            try
            {
                //Calling DbContext Class SaveChanges method 
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle the exception, possibly logging the details
                // The InnerException often contains more specific details
                throw new Exception(ex.Message, ex);
            }
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
