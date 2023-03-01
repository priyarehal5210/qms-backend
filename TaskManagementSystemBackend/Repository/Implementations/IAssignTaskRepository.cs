using TaskManagementSystemBackend.Controllers;
using TaskManagementSystemBackend.Models;
using TaskManagementSystemBackend.Repository.Interfaces;

namespace TaskManagementSystemBackend.Repository.Implementations
{
    public class IAssignTaskRepository : GenericRepository<AssignTasks>, IAssignTask
    {
        public IAssignTaskRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
