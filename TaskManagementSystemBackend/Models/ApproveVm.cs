namespace TaskManagementSystemBackend.Models
{
    public class ApproveVm
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
      //  public bool EmailConfirm { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string role { get; set; }
        public bool approved { get; set; }
    }
}
