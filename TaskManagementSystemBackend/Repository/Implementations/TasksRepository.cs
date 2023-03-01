using TaskManagementSystemBackend.Models;
using TaskManagementSystemBackend.Repository.Interfaces;

namespace TaskManagementSystemBackend.Repository.Implementations
{
    public class TasksRepository:GenericRepository<Tasks>,ITasks
    {
        private readonly ApplicationDbContext _context;
        public TasksRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }



        public StatusVm statusVm(RegisteredUsers registeredUsers, Tasks tasks)
        {
            var task = _context.assignedTasks.FirstOrDefault(x => x.RegisteredUsersId==registeredUsers.Id && x.TasksId==tasks.Id);
            if (task != null && task.Status!=AssignTasks.status.started)
            {
                task.Status = AssignTasks.status.started;
                task.Checked = true;
            }
            else
            {
                task.Status = AssignTasks.status.completed;
            }
            return null;
        }

    }
}
