namespace GradesApp.Common.Dtos.Authentication;

public class LoginDto
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public CustomClaimsDto CustomClaims { get; set; }
}