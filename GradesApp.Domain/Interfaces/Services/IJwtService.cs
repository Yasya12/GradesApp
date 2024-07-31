using GradesApp.Domain.Entities;

namespace GradesApp.Domain.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}