using TaskManagementSystemBackend.Models;
using TaskManagementSystemBackend.Repository.Interfaces;

namespace TaskManagementSystemBackend.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            register = new RegisteredUserRepository(_context);
            Tasks=new TasksRepository(_context);
            AssignTask = new IAssignTaskRepository(_context);
            userSuccess = new UserSucessRepository(_context);
          //  Login = new LoginUserRepository(_context);
        }
        public IRegister register { get; private set; }

        public ITasks Tasks { get; private set; }

        public IAssignTask AssignTask { get; private set; }

        public IUserSuccess userSuccess { get; private set; }


        //public ILoginUser Login { get; private set; }
    }
}
