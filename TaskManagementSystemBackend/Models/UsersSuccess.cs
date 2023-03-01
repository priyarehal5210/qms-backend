namespace TaskManagementSystemBackend.Models
{
    public class UsersSuccess
    {
        public int Id { get; set; }
     
        public string Date { get; set; }
        public string hours { get; set; }
        public int AssignTasksId { get; set; }
        public AssignTasks assignTasks { get; set; }
        public string success { get; set; }
    }
}
