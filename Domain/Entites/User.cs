using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Localizard.Domain.Entites;

public class User : IdentityUser
{
    [Key] 
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
}