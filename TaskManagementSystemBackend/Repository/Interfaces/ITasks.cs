using TaskManagementSystemBackend.Models;

namespace TaskManagementSystemBackend.Repository.Interfaces
{
    public interface ITasks:IGenericRepository<Tasks>
    {
        StatusVm statusVm(RegisteredUsers registeredUsers,Tasks tasks);
    }
}
