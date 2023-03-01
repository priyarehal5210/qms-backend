using TaskManagementSystemBackend.Models;
using TaskManagementSystemBackend.Repository.Interfaces;

namespace TaskManagementSystemBackend.Repository.Implementations
{
    public class RegisteredUserRepository:GenericRepository<RegisteredUsers>,IRegister
    {
        public RegisteredUserRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
