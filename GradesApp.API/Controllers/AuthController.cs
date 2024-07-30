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

    public AuthController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto model)
    {
        if (IsValidUser(model))
        {
            var token = _jwtService.GenerateToken(model);
            return Ok(new { token });
        }

        return Unauthorized();
    }

    private bool IsValidUser(LoginDto model)
    {
        // Implement credential validation
        return true; 
    }
}