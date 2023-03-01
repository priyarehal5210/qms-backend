using TaskManagementSystemBackend.Models;
using static TaskManagementSystemBackend.Models.Tasks;

namespace TaskManagementSystemBackend.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }


    }
}
