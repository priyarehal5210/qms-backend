namespace TaskManagementSystemBackend.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IRegister register { get; }
        ITasks Tasks { get; }
        IAssignTask AssignTask { get; }
        IUserSuccess userSuccess { get; }
    }
}
