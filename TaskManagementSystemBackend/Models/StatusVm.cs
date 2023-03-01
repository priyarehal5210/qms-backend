using System.Reflection.Metadata.Ecma335;

namespace TaskManagementSystemBackend.Models
{
    public class StatusVm
    {
        public RegisteredUsers registeredUsers { get; set; }
        public Tasks tasks { get; set; }
    }
}
