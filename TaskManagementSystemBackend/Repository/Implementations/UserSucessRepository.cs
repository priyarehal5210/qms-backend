using TaskManagementSystemBackend.Models;
using TaskManagementSystemBackend.Repository.Interfaces;

namespace TaskManagementSystemBackend.Repository.Implementations
{
    public class UserSucessRepository : GenericRepository<UsersSuccess>, IUserSuccess
    {
        public UserSucessRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
