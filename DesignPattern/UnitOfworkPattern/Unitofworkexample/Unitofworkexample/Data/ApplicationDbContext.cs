using Microsoft.EntityFrameworkCore;
using Unitofworkexample.Models;

namespace Unitofworkexample.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //We will store the connection string in AppSettings.json file instead of hard coding here
        }
    
     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //Adding Domain Classes as DbSet Properties
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
