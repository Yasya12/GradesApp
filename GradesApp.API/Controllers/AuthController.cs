using GradesApp.Application.Services;
using GradesApp.Common.Dtos.Authentication;
using GradesApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GradesApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly IUserService _userService;

    public AuthController(IJwtService jwtService, IUserService userService)
    {
        _jwtService = jwtService;
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var user = await _userService.GetUserByCredentialsAsync(model.UserName, model.Password);
    
        if (user != null)
        {
            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }

        return Unauthorized();
    }
}