using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace GradesApp.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLogin { get; set; }
}