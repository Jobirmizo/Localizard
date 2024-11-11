namespace Localizard.Domain.ViewModel;

public class UserDto
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}