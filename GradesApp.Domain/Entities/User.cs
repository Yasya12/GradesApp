using System.Text.Json.Serialization;

namespace GradesApp.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    
    [JsonIgnore]
    public virtual Student Student { get; set; }
}