using EShop.BLL.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("register")]
    public Task<IActionResult> Register([FromBody] CreateUserDto model)
    {
        throw new NotImplementedException();
    }

    [HttpPost("login")]
    public Task<IActionResult> Login()
    {
        throw new NotImplementedException();
    }

    [HttpPost("logout")]
    public Task<IActionResult> Logout()
    {
        throw new NotImplementedException();
    }

    [HttpPost("refresh-token")]
    public Task<IActionResult> RefreshToken()
    {
        throw new NotImplementedException();
    }
}