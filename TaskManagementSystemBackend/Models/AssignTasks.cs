using System.Text.Json.Serialization;

namespace TaskManagementSystemBackend.Models
{
    public class AssignTasks
    {
        public int Id { get; set; }
        public int RegisteredUsersId { get; set; }
        public RegisteredUsers registeredUsers { get; set; }
        public int TasksId { get; set; }
        public Tasks tasks { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public status Status { get; set; }

        public bool Checked { get; set; }
        public enum status
        {
            notstarted,
            started,
            progress,
            completed
        }
    }
}
