using Microsoft.EntityFrameworkCore;

namespace PracticeWebApplication.Models
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }
        public EmployeeDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {}

    }
}
