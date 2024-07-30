using GradesApp.Common.Dtos.Authentication;

namespace GradesApp.Domain.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(LoginDto model);
}