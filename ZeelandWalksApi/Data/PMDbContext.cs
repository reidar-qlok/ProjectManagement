using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.Models.Domain;

namespace ProjectManagerApi.Data
{
    public class PMDbContext : DbContext
    {
        public PMDbContext(DbContextOptions<PMDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Image> Images { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAssignment> ProjectAssignments { get; set; }
    }
}
