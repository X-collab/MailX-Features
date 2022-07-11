namespace LoginFunctionality.Models
{
    public class Credentials
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
        public bool IsLoggedIn { get; set; } = false;
    }
}
