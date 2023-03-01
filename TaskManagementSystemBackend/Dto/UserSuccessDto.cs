using MessagePack.Formatters;
using NuGet.Packaging.Signing;
using System.Globalization;
using System.Timers;
using TaskManagementSystemBackend.Models;

namespace TaskManagementSystemBackend.Dto
{
    public class UserSuccessDto
    {
        public string Date { get; set; }
        public int AssignTasksId { get; set; }
        public string success { get; set; }
        public string hours { get; set; }
    }
}
