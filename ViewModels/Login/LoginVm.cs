namespace bulletin.ViewModels.Login
{
    public class LoginVm
    {
        public string account { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string? code { get; set; }
    }
}
