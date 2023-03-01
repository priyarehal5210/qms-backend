using TaskManagementSystemBackend.Models;

namespace TaskManagementSystemBackend.Repository.Interfaces
{
    public interface ILoginUser
    {
        RegisteredUsers Login(string email, string password);
        ApproveVm approveUser(int Id,string username, string email, string password, string confirmPassword, string role, bool approved);
    }
}
