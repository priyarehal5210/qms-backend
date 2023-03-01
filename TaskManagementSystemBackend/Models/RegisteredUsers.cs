using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystemBackend.Models
{
    public class RegisteredUsers
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool EmailConfirm { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        public bool Approved { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
