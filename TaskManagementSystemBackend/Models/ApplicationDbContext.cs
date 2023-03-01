using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TaskManagementSystemBackend.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<RegisteredUsers>registeredUsers { get; set; }
        public DbSet<Tasks> tasks { get; set; }
        public DbSet<AssignTasks> assignedTasks { get; set; }
        public DbSet<UsersSuccess>usersSuccesses { get; set; }
    }
}
